using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextUhr
{
    public partial class Form1 : Form
    {
        string Zeit, Stunde, Minute;
        string Anfang = "Es ist ";
        string Mitte, Mitte2, Datum;
        int Min, Std;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Zeit = DateTime.Now.ToLongTimeString();
            Datum = DateTime.Now.ToLongDateString();
            label23.Text = Zeit;
            label1.Text = Datum;
            Stunde = Zeit.Substring(0,2);
            Minute = Zeit.Substring(3,2);
            Min = Convert.ToInt32(Minute);
            Std = Convert.ToInt32(Stunde);

            switch(Min)
            {
                case 0:
                    Mitte = "Um";
                    break;
                case 15:
                    Mitte = "Viertel";
                    Std = Std +1;
                    break;
                case 30:
                    Mitte = "Halb";                    
                    Std = Std +1;
                    break;                
                case 45:
                    Mitte = "Dreiviertel";
                    Std = Std + 1;
                    break;
                case 1:case 2:case 3:case 4:case 5:case 6:case 7:
                    Mitte = "kurz nach Um";
                    break;
                case 8:case 9:case 10:case 11:case 12:case 13:case 14:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz vor Viertel";
                    break;
                case 16:case 17:case 18:case 19:case 20:case 21:case 22:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz nach Viertel";
                    break;
                case 23:case 24:case 25:case 26:case 27:case 28:case 29:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz vor Halb";
                    break;
                case 31:case 32:case 33:case 34:case 35:case 36:case 37:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz nach Halb";
                    break;
                case 38:case 39:case 40:case 41:case 42:case 43:case 44:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz vor Dreiviertel";
                    break;
                case 46:case 47:case 48:case 49:case 50:case 51:case 52:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz nach Dreiviertel";
                    break;
                case 53:case 54:case 55:case 56:case 57:case 58:case 59:
                    Mitte2 = (Std + 1).ToString();
                    Mitte = "kurz vor Um";
                    break;
            }
            switch (Mitte2)
            {
                case "1":case "13":
                    Mitte2 = " Eins ";
                    break;
                case "2":case "14":
                    Mitte2 = " Zwei ";
                    break;
                case "3":case "15":
                    Mitte2 = " Drei ";
                    break;
                case "4":case "16":
                    Mitte2 = " Vier ";
                    break;
                case "5":case "17":
                    Mitte2 = " Fünf ";
                    break;
                case "6":case "18":
                    Mitte2 = " Sechs ";
                    break;
                case "7":case "19":
                    Mitte2 = " Sieben ";
                    break;
                case "8":case "20":
                    Mitte2 = " Acht ";
                    break;
                case "9":case "21":
                    Mitte2 = " Neun ";
                    break;
                case "10":case "22":
                    Mitte2 = " Zehn ";
                    break;
                case "11":case "23":
                    Mitte2 = " Elf ";
                    break;
                case "12":case "0":
                    Mitte2 = " Zwölf ";
                    break;
            }

            label22.Text = Anfang + Mitte + Mitte2;
        }
    }
}
