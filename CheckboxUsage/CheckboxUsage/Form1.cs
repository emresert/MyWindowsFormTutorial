using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckboxUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string language ="";
            if(checkBox1.Checked == true)
            {
                language = language + "," + checkBox1.Text;
            }
            if (checkBox2.Checked == true)
            {
                language = language + "," + checkBox2.Text;
            }
            if (checkBox3.Checked == true)
            {
                language = language + "," + checkBox3.Text;
            }
            if (checkBox4.Checked == true)
            {
                language = language + "," + checkBox4.Text;
            }
           
            label2.Text = language.Substring(1); 
            // removing first character (,) while displaying language
        }
    }
}
