//Benötigte Libs für MQTT,WLAN,Nextion-Display und Sensor
#include <Wire.h>
#include <Adafruit_BMP085.h>
#include <PubSubClient.h>
#include <Nextion.h>
#include <WiFi.h>

Adafruit_BMP085 bmp;
long last_time = 0;

//Definition WLAN und MQTT-Server
const char* ssid = "Your Router";
const char* password = "Your Password";
const char* mqtt_server = "Ip connect to MQTT ";

//Definition Port und Zugang MQTT
#define mqtt_port ****
#define MQTT_USER "User"
#define MQTT_PASSWORD "********"

//Definition für Anschlusspins des Displays
#define RXD2 16
#define TXD2 17

//für Wifi und MQTT-Datenübermittlung
WiFiClient wifiClient;
PubSubClient client(wifiClient);

//Deklaration für NExtion_Display Funktionen
NexPage p0 = NexPage(0,0,"page0");
NexPage p1 = NexPage(1,0,"page1");
NexButton p0_b0 = NexButton(0,1,"b0");
NexButton p1_b0 = NexButton(1,5,"b0");
NexPicture p0_p0 = NexPicture(0,2,"p0");
NexPicture p0_p1 = NexPicture(0,3,"p1");
NexPicture p0_p2 = NexPicture(0,4,"p2");
NexText p0_t0 = NexText(0,5,"tempTag1");
NexText p0_t1 = NexText(0,6,"tempTag2");
NexText p0_t2 = NexText(0,7,"tempTag3");
NexText p1_t2 = NexText(1,4,"temperatur");
NexNumber p0_x0 = NexNumber(0,8,"x0");
NexNumber p0_x1 = NexNumber(0,9,"x1");
NexNumber p0_x2 = NexNumber(0,10,"x2");


float temp0 = 2.0;
float temp1 = 2.90;
float temp2 = 2.0;
const char* sensortemp;
uint32_t pic0 = 1;
uint32_t pic1 = 1;
uint32_t pic2 = 1;

NexTouch *nex_listen_list[] ={&p0_b0, &p1_b0, NULL};

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

void reconnect(){
  // Connection loop
  while (!client.connected()){
    Serial.print("Attempting MQTT connection...");
    // Create a random client ID
    String clientId = "ESP32Client-";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    if (client.connect(clientId.c_str(),MQTT_USER,MQTT_PASSWORD)){
      Serial.println("connected");
             
      client.subscribe("/Wetterdaten/Temperatur/Aktuell");  
      client.subscribe("/Wetterdaten/Wetter/Icon/Heute");
      
      client.subscribe("/Wetterdaten/Temperatur/Morgen");
      client.subscribe("/Wetterdaten/Temperatur/Uebermorgen");
      client.subscribe("/Wetterdaten/Wetter/Icon/Morgen");
      client.subscribe("/Wetterdaten/Wetter/Icon/Uebermorgen");          
    }     
    else{
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}

void setup() {
  nexInit();  
  p0_b0.attachPop(p0_b0_Release, &p0_b0);
  p1_b0.attachPop(p1_b0_Release, &p1_b0);
  

  Serial.begin(115200);
  
  if (!bmp.begin()) {
  Serial.println("Could not find a valid BMP085/BMP180 sensor, check wiring!");
  while (1) {}
  }
  
  Serial.setTimeout(500);// Set time out for 
  setup_wifi();
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
  reconnect();  
}

void p0_b0_Release(void *ptr) {
  p1.show();
  p1_t2.setText (sensortemp);
}

void p1_b0_Release(void *ptr) {
p0.show();
//p0_t0.setText(temp0);
//p0_t1.setText(temp1);
//p0_t2.setText(temp2);
p0_x0.setValue(temp0);
p0_x1.setValue(temp1);
p0_x2.setValue(temp2);
p0_p0.setPic(pic0);
p0_p1.setPic(pic1);
p0_p2.setPic(pic2);
}

void temperfassung(){
  
  long now= millis();

  if (now - last_time > 3000){  
  //Serial.println(bmp.readTemperature());
  String fabc(bmp.readTemperature());
  sensortemp = fabc.c_str();
  p1_t2.setText (sensortemp);
  //Serial.println(sensortemp);
  //Serial.println(bmp.readPressure());
  //Serial.println(bmp.readAltitude());
  //Serial.println(bmp.readSealevelPressure());
  //Serial.println(bmp.readAltitude(102000));
  last_time = now;  
  }    
}

void callback(char* topic, byte *payload, unsigned int length){
  payload[length] = '\0';
  String sTopic = String(topic);  
   
  
  if(sTopic == "/Wetterdaten/Temperatur/Aktuell"){
    
    temp0 = String((char*)payload).toFloat()*10;
    p0_x0.setValue(temp0);
    //p0_t0.setText(temp0);
    Serial.println(temp0);
    Serial.println(temp1);
    Serial.println(temp2);      
  }
  if(sTopic == "/Wetterdaten/Temperatur/Morgen"){
    
    temp1 = String((char*)payload).toFloat()*10;
    p0_x1.setValue(temp1);
    //p0_t1.setText(temp1);
    Serial.println(temp0);
    Serial.println(temp1);
    Serial.println(temp2);   
  }
  if(sTopic == "/Wetterdaten/Temperatur/Uebermorgen"){
        
    temp2 = String((char*)payload).toFloat()*10;
    p0_x2.setValue(temp2);
    //p0_t2.setText(temp2);
    Serial.println(temp0);
    Serial.println(temp1);
    Serial.println(temp2);   
  }
  if (sTopic == "/Wetterdaten/Wetter/Icon/Heute"){
    pic0 = String((char*)payload).toInt();
    p0_p0.setPic(pic0);
  }
  if (sTopic == "/Wetterdaten/Wetter/Icon/Morgen"){
    pic1 = String((char*)payload).toInt();
    p0_p1.setPic(pic1);
  }
  if (sTopic == "/Wetterdaten/Wetter/Icon/Uebermorgen"){
    pic2 = String((char*)payload).toInt();
    p0_p2.setPic(pic2);
  }  
}

void loop() {
  reconnect();
  client.loop();
  nexLoop(nex_listen_list);
  temperfassung();    
}
