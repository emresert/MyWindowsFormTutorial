using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayi = 0, tahminSayisi = 0, puan = 1000;

        private void button1_Click(object sender, EventArgs e)
        {
            int tahmin;
            tahminSayisi++;
            if(tahminSayisi <= 10)
            {
                tahmin = int.Parse(textBox1.Text);
                label6.Text = tahminSayisi.ToString();
                if (tahmin > sayi)
                {
                    label5.ForeColor = System.Drawing.Color.Red;
                    label5.Text = "Tahmininizi azaltınız.";
                    puan = puan - 100;
                    label7.Text = puan.ToString();

                }
                else if (tahmin < sayi) {
                    label5.ForeColor = System.Drawing.Color.Green; //change color for label
                    label5.Text = "Tahmininizi arttırınız.";
                    puan = puan - 100;
                    label7.Text = puan.ToString();
                }
                else {
                    label5.ForeColor = System.Drawing.Color.DodgerBlue;
                    label5.Text = "Tebrikler! " + tahminSayisi + " seferde bilip " + puan + " ile oyunu tamamladınız.";
                    button2.Enabled = true;
                    button1.Enabled = false;
                    tahminSayisi = 0;
                }
                textBox1.Text = "";
            }
            if(tahminSayisi == 11)
            {
                textBox1.Enabled = false;
                MessageBox.Show("Tahmin hakkınız kalmadığı için oyun kapatılacak.");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = true;
            Random rnd = new Random();
            sayi = rnd.Next(1, 100);  //rnd.Next(100)  between 0 and 100
            label8.Text = Convert.ToString(sayi); // sayi.ToString();
            label5.Text = "";
            label6.Text = "0";
            label7.Text = "1000";
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
        }
    }
}
