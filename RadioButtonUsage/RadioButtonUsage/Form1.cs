using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioButtonUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label2.Text = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                label2.Text = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                label2.Text = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                label2.Text = radioButton4.Text;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                this.BackColor = Color.White;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton5.Checked == true)
            {
                this.BackColor = Color.OrangeRed;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton6.Checked == true)
            {
                this.BackColor = Color.DodgerBlue;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton8.Checked == true)
            {
                this.BackColor = Color.Pink;
            }
        }
    }
}
