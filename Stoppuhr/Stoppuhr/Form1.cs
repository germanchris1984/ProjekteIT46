using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stoppuhr
{
    public partial class Form1 : Form
    {
        double Zeit = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Zeit.ToString("00:00");
            Zeit = Zeit + 0.1;
            timer1.Interval = 100;
        }

        private void start_BTN_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Stop_BTN_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Reset_BTN_Click(object sender, EventArgs e)
        {
            Zeit = 0;
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            listBox1.Items.Add(label1.Text);
        }
    }
}
