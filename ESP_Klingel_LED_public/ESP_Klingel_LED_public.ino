#include <PubSubClient.h>
#include <WiFi.h>

long last_time_gong = 0;
//int speakerPin = 25;

//"happy birthday melody notes"
char notes[] = "GGAGcB GGAGdc GGxecBA yyecdc";
//char notes[] = "AAAfC";
int beats[] = { 2, 2, 8, 8, 8, 16, 1, 8, 2, 8, 8, 8, 16, 1, 2, 2, 8, 8, 8, 8, 16, 1, 8, 2, 8, 8, 8, 16 };

const char* ssid = "Your Router";
const char* password = "******";
const char* mqtt_server = "IP connect MQTT";
#define led_klingel_oben 18
#define led_klingel_unten 19
#define speaker 25
#define mqtt_port 1883
#define MQTT_USER "User"
#define MQTT_PASSWORD "*******"

WiFiClient wifiClient;
PubSubClient client(wifiClient);

void setup_wifi() 
{
  
    delay(10);
    // We start by connecting to a WiFi network
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(ssid);
    WiFi.begin(ssid, password);
    while (WiFi.status() != WL_CONNECTED) 
    {
      delay(500);
      Serial.print(".");
    }
    randomSeed(micros());
    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());
}

void reconnect() 
{
  // Loop until we're reconnected
  while (!client.connected()) 
  {
    Serial.print("Attempting MQTT connection...");
    // Create a random client ID
    String clientId = "ESP32Client-";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    if (client.connect(clientId.c_str(),MQTT_USER,MQTT_PASSWORD)) 
    {
      Serial.println("connected");
      //Once connected, publish an announcement...
      
      client.publish("/icircuit/presence/ESP32/", "hello world");
      // ... and resubscribe
      client.subscribe("/Home/draussen/esptor/klingel_unten");  
      client.subscribe("/Home/draussen/esptor/klingel_oben");    
    }     
    else 
    {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}

void playTone(int tone) {
  for (long i = 0; i < 100; i++) {
    sigmaDeltaWrite(0, 0);
    delayMicroseconds(tone);
    sigmaDeltaWrite(0, 100);
    delayMicroseconds(tone);
  }
}

void playNote(char note) {
  //notes
  char note_name[] = {'C',  'D',  'E',  'F',  'G',  'A',  'B',  'c',  'd',  'e',  'f',  'g',  'a',  'b', 'x',  'y' }; 
  int timeHigh[] = { 1915, 1700, 1519, 1432, 1275, 1136, 1014, 956,  834,  765,  593,  468,  346,  224, 655 , 715 };
  // play the tone corresponding to the note name
  for (int i = 0; i < sizeof(note_name); i++) {
    if (note_name[i] == note) {
      playTone(timeHigh[i]);
    }
  }
}

void callback(char* topic, byte *payload, unsigned int length){

  payload[length] = '\0';
  String sTopic = String(topic);
  if(sTopic == "/Home/draussen/esptor/klingel_unten"){
   led_licht_unten();  
  }
  
  if(sTopic == "/Home/draussen/esptor/klingel_oben"){
   led_licht_oben(); 
   sigmaDeltaWrite(0, 0);
   digitalWrite(speaker, LOW);
      
  }
}

void setup() 
{
  Serial.begin(115200);
  Serial.setTimeout(500);// Set time out for 
  setup_wifi();
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
  reconnect();  
  pinMode(led_klingel_unten, OUTPUT);
  pinMode(led_klingel_oben, OUTPUT);
  pinMode(speaker, OUTPUT);
  digitalWrite(speaker, LOW);
  digitalWrite(led_klingel_oben, LOW);
  digitalWrite(led_klingel_unten, LOW);

  sigmaDeltaSetup(0, 12000);
  //attach pin speakerPin to channel 0
  sigmaDeltaAttachPin(speaker, 0);
  //initialize channel 0 to off
  sigmaDeltaWrite(0, 0);
}

void led_licht_oben(){  
  digitalWrite(led_klingel_oben, HIGH);
  delay(2000);
  digitalWrite(led_klingel_oben, LOW);
  
  digitalWrite(speaker, HIGH);
  for (int i = 0; i < strlen(notes); i++) {
    // space is rest note
    if (notes[i] == ' ') {
      delay(beats[i] * 100); 
    } else {
      playNote(notes[i]);
    }
    // pause between notes
    delay(100);
  }
}
void led_licht_unten(){
  digitalWrite(led_klingel_unten, HIGH);
  delay(2000);
  digitalWrite(led_klingel_unten, LOW);
}
void loop() 
{  
   client.loop();   
}
