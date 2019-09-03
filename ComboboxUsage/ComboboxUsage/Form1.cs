using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboboxUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("AUDI");
            comboBox1.Items.Add("BMW");
            comboBox1.Items.Add("VOLKSWAGEN");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "AUDI")
            {
                comboBox2.Items.Clear(); // We must clear items since there should not more model for another marka and model
                comboBox2.Items.Add("A1");
                comboBox2.Items.Add("A2");
                comboBox2.Items.Add("A3");
            }
            else if (comboBox1.Text =="BMW")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("320");
                comboBox2.Items.Add("520");
                comboBox2.Items.Add("X5");
            }
            else if (comboBox1.Text == "VOLKSWAGEN")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Polo");
                comboBox2.Items.Add("Passat");
                comboBox2.Items.Add("Caddy");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "A1")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("1.2"); // Method 1 to display models
                comboBox3.Items.Add("1.4");
                comboBox3.Items.Add("1.5");
            }
            else if (comboBox2.Text == "A2")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("1.3");
                comboBox3.Items.Add("1.6");
                comboBox3.Items.Add("2.0");
            }
            else if (comboBox2.Text == "A3")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Comfort");
                comboBox3.Items.Add("HP");
                comboBox3.Items.Add("Sedan");
            }

            else if (comboBox2.Text == "320")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("SMALL");
                comboBox3.Items.Add("MEDIUM");
                comboBox3.Items.Add("LARGE");
            }
            else if (comboBox2.Text == "520")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("L");
                comboBox3.Items.Add("XL");
                comboBox3.Items.Add("XXL");
            }
            else if (comboBox2.Text == "X5")
            {
                comboBox3.Items.Clear();
                string[] x5Models = { "Q3", "Q6", "Q7" };
                comboBox3.Items.AddRange(x5Models); 
                // Method 2 to display models
              
            }
            else if (comboBox2.Text == "Polo")
            {
                comboBox3.Items.Clear();
                string[] poloModels = { "p1", "p2", "p3" };
                comboBox3.Items.AddRange(poloModels);
            }
            else if (comboBox2.Text == "Passat")
            {
                comboBox3.Items.Clear();
                string[] passatModels = { "pas1", "pas2", "pas3" };
                comboBox3.Items.AddRange(passatModels);
            }
            else if (comboBox2.Text == "Caddy")
            {
                comboBox3.Items.Clear();
                string[] caddyModels = { "c1", "c2", "c3" };
                comboBox3.Items.AddRange(caddyModels);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Marka " + comboBox1.Text + " | " + "Model " + comboBox2.Text + " | " + "Versiyon " + comboBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
