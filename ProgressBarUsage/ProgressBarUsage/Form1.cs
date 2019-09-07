using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 25;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 50;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 75;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar2.Maximum = 1000;
            progressBar2.Step = 10;
            progressBar3.Maximum = 11;
            textBox1.MaxLength = 11;
            progressBar4.Style = ProgressBarStyle.Marquee; // change progress bar style
            progressBar4.MarqueeAnimationSpeed = 10;
            timer1.Interval = 10000;
            timer1.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            progressBar2.PerformStep();
            // it will increase progressbar value according to step value
            // till progress bar will reach maximum value 
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            progressBar3.Value = textBox1.Text.Length;
        }
        int i = 0; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            // when tick event starts , i will increase and code between if case will start.
            if(i == 1)
            {
                timer1.Stop();
                this.Hide();
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }
    }
}
