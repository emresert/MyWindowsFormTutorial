using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsUsageofFormObject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            textBox3.Text = "1";
            radioButton1.Checked = true;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double birimFiyat = Convert.ToDouble(textBox2.Text);
                double adet = Convert.ToDouble(textBox3.Text);
                double tutar = birimFiyat * adet;
                double kdv = 0;
                if (radioButton1.Checked == true)
                {
                    kdv = tutar * 0.75;
                }
                else if (radioButton2.Checked == true)
                {
                    kdv = tutar * 0.18;
                }
                if (radioButton3.Checked == true)
                {
                    kdv = tutar * 0.08;
                }
                tutar = tutar + kdv;
                if(checkBox1.Checked == true)
                {
                    tutar = tutar - tutar * 0.10;
                }

                textBox4.Text = kdv.ToString();
                textBox5.Text = tutar.ToString();
            }
            catch 
            {

                
            }
           
        }
    }
}
//Details on this link
//https://www.youtube.com/watch?v=7_UWxvG8h_8&list=PLSuhOGv534vTFRq9dFB9Yn7su-4hIc0xg&index=17