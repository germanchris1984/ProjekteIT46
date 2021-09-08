using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reaktionstest
{
    public partial class Form1 : Form
    {
        //Deklarieren
        Random zZahl = new Random();
        DateTime start;
        TimeSpan spanne;
        int wert, warten;
        bool schalter = false;

        public Form1()
        {
            InitializeComponent();
            button1.Text = "Start"; // Buttontext bei Progammstart
        }       


        private void button1_Click(object sender, EventArgs e)
        {
            if(schalter)// wenn schalter ist true heißt schalter ist NOCH NICHT gedrückt
            {
                schalter = false; // Zustand nach dem drücken des Schalters
                button1.Text = "Start";
                spanne = DateTime.Now - start; //Berechnung der Differenz vom letzt Knopfdruck
                label1.Text = spanne.TotalMilliseconds.ToString("0.00") + "ms";

                if (spanne.TotalMilliseconds < 10)
                {
                    label4.Text = "Betrüger";
                }
                else if (spanne.TotalMilliseconds < 200)
                {
                    label4.Text = "Ausgezeichnet";
                }
                else if (spanne.TotalMilliseconds < 250)
                {
                    label4.Text = "sehr gut";
                }
                else if (spanne.TotalMilliseconds < 300)
                {
                    label4.Text = "gut";
                }
                else if (spanne.TotalMilliseconds < 400)
                {
                    label4.Text = "geht so";
                }
                else if (spanne.TotalMilliseconds < 500)
                {
                    label4.Text = "schlecht";
                }
                else
                {
                    label4.Text = "Schlafen Sie?";
                }
            }
            else // eigentlicher PROGRAMMSTART -->     
            {
                pictureBox2.Hide(); //versteckt Rot,
                label4.Text = "...";
                label1.Text = "...";
                warten = 0; // setzt Zählvariable zurück
                wert = zZahl.Next(1, 7); //erstellt zufallszahl,
                timer1.Start(); //startet Timer,
                pictureBox1.Show(); // zeigt Grün
            }
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {            

            if(wert == warten) // wenn zufallszahl mit der Zählvariable übereinstimmt tu das..
            {
                schalter = true; 
                start = DateTime.Now;  //Variable zählt aktuell gebrauchte Zeit
                button1.Text = "Stopp"; // Button heißt jetzt Stopp
                timer1.Stop(); //Timer wird gestoppt
                pictureBox2.Show(); //Rot wird gezeigt
                                            
            }
            warten++; //Zählervariable zählt bis zufallszahl

        }
    }
}
