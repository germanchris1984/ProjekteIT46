using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Zinsrechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
            this.chart1.Titles.Add("Jahreszinsen");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();

            if ((textBox1.Text !=  "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                decimal Anfangsbetrag, Betrag, Zinsensatz, Zinsen, Endbetrag;
                int Jahr;
                Betrag = Convert.ToDecimal(textBox1.Text);
                Jahr = Convert.ToInt32(textBox2.Text);
                Zinsensatz = Convert.ToDecimal(textBox3.Text);
                Anfangsbetrag = Betrag;            
                dataGridView1.RowCount = Jahr;     
                
                Series series    = this.chart1.Series.Add("Endbetrag");
                Series series1 = this.chart1.Series.Add("Zinsen");
                series.ChartType = SeriesChartType.Spline;
                series1.ChartType = SeriesChartType.Spline;

                for (int i = 0; i < Jahr; i++)
                {
                    dataGridView1[0, i].Value = (i + 1).ToString();
                    dataGridView1[1, i].Value = Anfangsbetrag;
                    dataGridView1[1, i].Value = Anfangsbetrag.ToString("0.00€");
                    Zinsen = Anfangsbetrag / 100 * Zinsensatz;

                    dataGridView1[2, i].Value = Zinsen;
                    dataGridView1[2, i].Value = Zinsen.ToString("0.00€");
                    Endbetrag = Anfangsbetrag + Zinsen;

                    dataGridView1[3, i].Value = Endbetrag;
                    dataGridView1[3, i].Value = Endbetrag.ToString("0.00€");
                    Anfangsbetrag = Endbetrag;

                    textBox4.Text = Endbetrag.ToString("0.00€");

                    series.Points.AddXY("Jahr" + (i+1), Endbetrag);
                    series1.Points.AddXY("Zinsen" + (i+1), Zinsen);                
                }
            }
            else
            {
                MessageBox.Show("Wert fehlt!");
            }            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dataGridView1.Columns.Clear();
            this.chart1.Series.Clear();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}
