using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer_PictureBox_ImageListUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int salise = 0,saniye =0,dakika = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // for a second
            timer1.Enabled  = true;
            timer2.Interval = 10 ; // for a split-second
            pictureBox1.Image = ımageList1.Images[0]; // it should be ı not i .

            label5.Text = "0";
            label6.Text = "0";
            label7.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        int i = 0; // index variable for  picture array

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            i++;
            if(i==12){
                i = 0;
            }
            pictureBox1.Image = ımageList1.Images[i];
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            salise++;
            if(salise == 100)
            {
                salise = 0;
                if (saniye == 60)
                {
                    dakika++;
                    saniye = 0;
                }
                saniye++;
            }
            label5.Text = dakika.ToString();
            label6.Text = saniye.ToString();
            label7.Text = salise.ToString();
        }
    }
}
