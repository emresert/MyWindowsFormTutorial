using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransitionBetweenFormsAndDataTransfering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // We have created an object from Form2 after setting form1 objects as public
            Form2 f2 = new Form2();
            f2.label4.Text = textBox1.Text;

            double y1 = Convert.ToDouble(textBox2.Text);
            double y2 = Convert.ToDouble(textBox3.Text);
            double y3 = Convert.ToDouble(textBox4.Text);
            double ortalama = (y1 + y2 + y3) / 3;
            f2.label5.Text = ortalama.ToString();
            if(ortalama < 50)
            {
                f2.label6.Text = "Başarısız";
            }
            else
            {
                f2.label6.Text = "Başarılı";
            }
            f2.ShowDialog();
        }
    }
}
