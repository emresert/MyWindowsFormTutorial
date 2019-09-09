using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorProviderUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errorProvider1.BlinkRate = 400;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            //textBox1.MaxLength = 11;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length < 11 || textBox1.Text.Length > 11)
            {
                errorProvider1.SetError(textBox1, "T.C. Kimlik No 11 karakter olmalıdır!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
