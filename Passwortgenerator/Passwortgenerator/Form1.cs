using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwortgenerator
{
    public partial class Form1 : Form
    {        
        string Vorlage;
        string Passwort;
        string VorlageKombi;
        int Position;
        int min;
        Random zahl = new Random();        

        public Form1()
        {
            InitializeComponent();
            button2.Hide();
        }
        private void generate()
        {
            //Generieren
            if (checkBox1.Checked) //Buchstaben
            {
                Vorlage = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                VorlageKombi += Vorlage;
            }
            if (checkBox2.Checked) //Ziffern
            {
                Vorlage = "0123456789";
                VorlageKombi += Vorlage;
            }
            if (checkBox3.Checked) //Sonderzeichen
            {
                Vorlage = "!\"§$%&/()=?#+*_,.;:@€><";
                VorlageKombi += Vorlage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Eingabe
            label3.Text = "";
            VorlageKombi = "";
            Vorlage = "";
            Passwort = "";
            Position = 0;
                        
            generate();

            if ((!checkBox1.Checked) && (!checkBox2.Checked) && (!checkBox3.Checked))
            {
                textBox1.Text = "Fehler!";
                textBox1.BackColor = Color.OrangeRed;
                return;
            }

            //Verabeitung           
            min = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < min; i++)
            {
            Position = zahl.Next(0,VorlageKombi.Length);//zufallszahl erstellen            
            Passwort = Passwort + VorlageKombi[Position].ToString(); //Passwort zufällig auswählen
            }

            if(min < 4)
            {
                textBox1.BackColor = Color.OrangeRed;
            }
            if(min >= 4)
            {
                textBox1.BackColor = Color.Yellow;
            }
            if((min > 6) && (checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked))
            {
                textBox1.BackColor = Color.LightGreen;
            }

            //Ausgabe
            textBox1.Text = Passwort;
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            button2.Hide();
            label3.Text = "Das Passwort wurde in die Zwischenablage kopiert!";
            label3.ForeColor = Color.Green;
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            min = Convert.ToInt32(numericUpDown1.Value);
            for (int j = 0; j < min; j++)
            {
                Passwort = "";
                VorlageKombi = "";
                for (int i = 0; i < min; i++)
                {            
                    generate();
                    Position = zahl.Next(0, VorlageKombi.Length);//zufallszahl erstellen
                    Passwort += VorlageKombi[Position].ToString(); //Passwort zufällig auswählen                                
                }
                listBox1.Items.Add(Passwort);       
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Passwort = "";
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox1.BackColor = Color.White;
        }        
    }    
}
