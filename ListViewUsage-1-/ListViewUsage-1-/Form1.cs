using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewUsage_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add( "TC Kimlik No", 100); // Second one is weight
            listView1.Columns.Add( "Ad Soyad",     200);
            listView1.Columns.Add( "Yaş",           50);
            listView1.Columns.Add( "Mezuniyet",    150);
            listView1.Columns.Add( "Cinsiyet",     75);
            listView1.Columns.Add( "Doğum Yeri",   125);
            listView1.Columns.Add( "Telefon No",   130);
            // we need to change view property of listview as Details on Properties Screen 
            // checkboxes feature should be true to select item of Listview with checkbox.
            // fullrowselect should be true on properties window of listview to select all row.
            string[] mezuniyet = { "İlköğretim", "Lise", "Önlisans", "Lisans", "Yüksek Lisans" };
            comboBox1.Items.AddRange(mezuniyet);
            kayitSayisiDondur(); // call the function for record count
        }
        
        private void kayitSayisiDondur()
        {
            int kayitSayisi = listView1.Items.Count;
            label8.Text = Convert.ToString(kayitSayisi);
        }

        // Adding a new record
        private void button2_Click(object sender, EventArgs e)
        {
            string tc = "", adSoyad = "", yas = "", mezuniyet = "", cinsiyet = "", dogumYeri = "", telNo = "";
            tc = textBox1.Text;
            adSoyad = textBox2.Text;
            yas = textBox3.Text;
            mezuniyet = comboBox1.Text;
            if (radioButton1.Checked == true)
            {
                cinsiyet = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                cinsiyet = radioButton2.Text;
            }
            dogumYeri = textBox4.Text;
            telNo = textBox5.Text;

            string[] bilgiler = { tc, adSoyad, yas,mezuniyet, cinsiyet, dogumYeri, telNo };
            bool tcKontrol = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                //subitem determines to check column which we want to check with index
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    tcKontrol = true;
                    MessageBox.Show("Aynı T.C. numarasına ait bir kayıt var");
                }
            }
                if (tcKontrol == false)
                {
                    ListViewItem lw = new ListViewItem(bilgiler);
                    if (tc != "" && adSoyad != "" && yas !="" && mezuniyet !="" && cinsiyet !="" && dogumYeri != "" && telNo!="" )
                    {
                        listView1.Items.Add(lw);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt bilgilerini eksiksiz doldurunuz");
                    }
                    
                }
                kayitSayisiDondur();
            }

        // // Deleting a record with CheckedItems feature
        private void button3_Click(object sender, EventArgs e)
        {
            int secilenSayisi = listView1.CheckedItems.Count;
            foreach (ListViewItem seciliKayitBilgisi in listView1.CheckedItems)
            {
                seciliKayitBilgisi.Remove();

            }
            MessageBox.Show(secilenSayisi.ToString() + " adet kayıt silindi");
            kayitSayisiDondur();
        }

        // Deleting a record with SelectedItems feature
        private void button4_Click(object sender, EventArgs e)
        {
            int secilenSayisi = listView1.SelectedItems.Count;
            foreach (ListViewItem seciliKayitBilgisi in listView1.SelectedItems)
            {
                seciliKayitBilgisi.Remove();

            }
            MessageBox.Show(secilenSayisi.ToString() + " adet kayıt silindi");
            kayitSayisiDondur();
        }

        // Delete all record
        private void button5_Click(object sender, EventArgs e)
        {
            int adet = 0;
            adet = listView1.Items.Count;
            listView1.Items.Clear();
            MessageBox.Show(adet + " adet kayıt silindi");
            kayitSayisiDondur();
        }

        // Finding a record
        private void button1_Click(object sender, EventArgs e)
        {
            bool arananKayit = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    arananKayit    = true;
                    textBox2.Text  = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text  = listView1.Items[i].SubItems[2].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[3].Text;
                    if(listView1.Items[i].SubItems[4].Text == radioButton1.Text)
                    {
                        radioButton1.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[4].Text == radioButton2.Text)
                    {
                        radioButton2.Checked = true;
                    }
                    textBox4.Text = listView1.Items[i].SubItems[5].Text;
                    textBox5.Text = listView1.Items[i].SubItems[6].Text;

                    textBox2.Enabled  = false;
                    textBox3.Enabled  = false;     
                    textBox4.Enabled  = false;
                    textBox5.Enabled  = false;
                    comboBox1.Enabled = false;
                    groupBox1.Enabled = false;
                }
            }
            if (arananKayit == false)
            {
                MessageBox.Show("Böyle bir T.C. No ya ait kayıt bulunmamaktadır.");
            }
        }

        // Starting a new record
        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            groupBox1.Enabled = true;
        }
    }
}
