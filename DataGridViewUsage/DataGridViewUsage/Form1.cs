using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Db baglantısı için eklendi

namespace DataGridViewUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection(
            "Provider=Microsoft.ACE.OleDb.12.0; Data Source=" +
            Application.StartupPath + "\\testDb.accdb");

        private void kayitlariListele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from aracTest", baglantim);
                DataSet dsHafiza = new DataSet(); // sorgu sonuçlarını tutar
                listele.Fill(dsHafiza);
                dataGridView1.DataSource = dsHafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hataMsj)
            {
                MessageBox.Show(hataMsj.Message);
                baglantim.Close();
                
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Combobox stil tanımlama
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            //Araç marka Tipi, Yakıt ve Kasa Tipi
            string[] yakitTipi = { "Benzinli", "Dizel", "Lpg" };
            string[] kasaTipi = { "Sedan", "Hatchback" };
            string[] markaTipi = {"Toyota","Honda","Opel" };
            // Tipler Eklendi
            comboBox1.Items.AddRange(markaTipi);
            comboBox3.Items.AddRange(yakitTipi);
            comboBox4.Items.AddRange(kasaTipi);

            kayitlariListele(); // grid view'in içini doldurduk

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // alt alta farklı kategoride araçlar gelmemesi için temizledik
            comboBox2.Items.Clear(); 
            string marka = comboBox1.SelectedItem.ToString();

            if (marka=="Toyota") {
                string[] model = {"Auris","Yaris","Corolla" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Honda")
            {
                string[] model = { "Civic", "Accord"};
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Opel")
            {
                string[] model = { "Astra", "Vectra", "Corsa" };
                comboBox2.Items.AddRange(model);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
