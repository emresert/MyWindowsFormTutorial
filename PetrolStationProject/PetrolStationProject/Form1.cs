﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolStationProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Depodaki yakıtların değişkenleri oluşturuldu  baş harf 'd'
        double dBenzin95 = 0, dBenzin97 = 0, dDizel = 0, dEuroDizel = 0, dLpg = 0;
        // Eklenen yakıtların değişkenleri oluşturuldu   baş harf 'e'
        double eBenzin95 = 0, eBenzin97 = 0, eDizel = 0, eEuroDizel = 0, eLpg = 0;
        // Depodaki yakıtların fiyatları için değişkenler oluşturuldu baş harf 'f'
        double fBenzin95 = 0, fBenzin97 = 0, fDizel = 0, fEuroDizel = 0, fLpg = 0;
        // Depodan satılan yakıtların değişkenleri oluşturuldu  baş harf 's'
        double sBenzin95 = 0, sBenzin97 = 0, sDizel = 0, sEuroDizel = 0, sLpg = 0;

        

        // Txt belgelerinin içindeki değerler bu dizilere aktarılacak
        // bin dosyası içindeki fiyat ve depo txt belgeleri
        string[] depoBilgileri;
        string[] fiyatBilgileri;

        
      

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // yakitTurleri "Benzin95", "Benzin97", "Dizel", "Euro Dizel", "LPG" 
            // Comboboxdaki değerlere göre Yakıt türü seçildiğinde 
            // numericupdown nesnelerinin görünürlük olayları
           if (comboBox1.Text == "Benzin95")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
           else if (comboBox1.Text == "Benzin97")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Euro Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }

           // seçimi değiştirdikten sonra değişiklikleri sıfırla
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label28.Text = "________";

        }
        // private method yalnızca bu sınıfta çalışır 
        // public method başka sınıflarda da çalışabilir

        // depo.txt dosyasından okuma
        private void txt_depo_oku()
        {
            depoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            dBenzin95  = Convert.ToDouble(depoBilgileri[0]);
            dBenzin97  = Convert.ToDouble(depoBilgileri[1]);
            dDizel     = Convert.ToDouble(depoBilgileri[2]);
            dEuroDizel = Convert.ToDouble(depoBilgileri[3]);
            dLpg       = Convert.ToDouble(depoBilgileri[4]);

        }
        // label nesneleri için txt dosyasından veriyi ekrana yazma
        private void txt_depo_yaz()
        {
            // ("N") Karakteri virgülden sonraki basamak sayısını 2 ye ayarlar.
            label6.Text  = dBenzin95.ToString("N");
            label7.Text  = dBenzin97.ToString("N");
            label8.Text  = dDizel.ToString("N");
            label9.Text  = dEuroDizel.ToString("N");
            label10.Text = dLpg.ToString("N");

        }

        // fiyat.txt dosyasından okuma
        private void txt_fiyat_oku()
        {
            fiyatBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            fBenzin95 = Convert.ToDouble(fiyatBilgileri[0]);
            fBenzin97 = Convert.ToDouble(fiyatBilgileri[1]);
            fDizel = Convert.ToDouble(fiyatBilgileri[2]);
            fEuroDizel = Convert.ToDouble(fiyatBilgileri[3]);
            fLpg = Convert.ToDouble(fiyatBilgileri[4]);
        }
        // label nesneleri için txt dosyasından veriyi ekrana yazma
        private void txt_fiyat_yaz()
        {
            label16.Text = fBenzin95.ToString("N");
            label17.Text = fBenzin97.ToString("N");
            label18.Text = fDizel.ToString("N");
            label19.Text = fEuroDizel.ToString("N");
            label20.Text = fLpg.ToString("N");
        }

        // Depodaki değerlere göre progress barların doluluk oranlarını gösterme
        private void progressbar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(dBenzin95);
            progressBar2.Value = Convert.ToInt16(dBenzin97);
            progressBar3.Value = Convert.ToInt16(dDizel);
            progressBar4.Value = Convert.ToInt16(dEuroDizel);
            progressBar5.Value = Convert.ToInt16(dLpg);
        }

        // numericupdown nesnelerinin maximum değerlerini ayarlama
        private void numericupdown_value()
        {
            // double direk decimale dönüşmez önce stringe sonra decimale çevirilir.
            numericUpDown1.Maximum = decimal.Parse(dBenzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(dBenzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(dDizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(dEuroDizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(dLpg.ToString());


        }

        //depo bilgilerini güncelleme
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                eBenzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < dBenzin95 + eBenzin95 || eBenzin95 <= 0)
                {
                    textBox1.Text = "Hata!!";

                }
                else
                {
                    // depodaki benzin + ilave edilen benzin
                    depoBilgileri[0] = Convert.ToString(dBenzin95 + eBenzin95);
                }
            }
            catch (Exception)
            {
                textBox1.Text = "Hata!!";
            }

            try
            {
                eBenzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < dBenzin97 + eBenzin97 || eBenzin97 <= 0)
                {
                    textBox2.Text = "Hata!!";

                }
                else
                {
                    depoBilgileri[1] = Convert.ToString(dBenzin97 + eBenzin97);
                }
            }
            catch (Exception)
            {
                textBox2.Text = "Hata!!";
            }
            try
            {
                eDizel = Convert.ToDouble(textBox3.Text);
                if (1000 < dDizel + eDizel || eDizel <= 0)
                {
                    textBox3.Text = "Hata!!";

                }
                else
                {
                    depoBilgileri[2] = Convert.ToString(dDizel + eDizel);
                }
            }
            catch (Exception)
            {
                textBox3.Text = "Hata!!";
            }
            try
            {
                eEuroDizel = Convert.ToDouble(textBox4.Text);
                if (1000 < dEuroDizel + eEuroDizel || eEuroDizel <= 0)
                {
                    textBox4.Text = "Hata!!";

                }
                else
                {
                    depoBilgileri[3] = Convert.ToString(dEuroDizel + eEuroDizel);
                }
            }
            catch (Exception)
            {
                textBox4.Text = "Hata!!";
            }
            try
            {
                eLpg = Convert.ToDouble(textBox5.Text);
                if (1000 < dLpg + eLpg || eLpg <= 0)
                {
                    textBox5.Text = "Hata!!";

                }
                else
                {
                    depoBilgileri[4] = Convert.ToString(dLpg + eLpg);
                }
            }
            catch (Exception)
            {
                textBox5.Text = "Hata!!";
            }

            // txt dosyasındaki değerleri güncelleme
            // üzerine yazma işlemi
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depoBilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressbar_guncelle();
            numericupdown_value();

        }

        //fiyat bilgilerini güncelleme
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // fiyat = fiyat + (f * girilen yeni fiyat / 100)
                // oran orantı ile fiyat arttırıldı.
                // 100,  % 'lik hesaptan geliyor.
                fBenzin95 = fBenzin95 + (fBenzin95 * Convert.ToDouble(textBox6.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(fBenzin95);

            }
            catch (Exception)
            {

                textBox6.Text = "Hata!!";
            }
            try
            {
                fBenzin97 = fBenzin97 + (fBenzin97 * Convert.ToDouble(textBox7.Text) / 100);
                fiyatBilgileri[1] = Convert.ToString(fBenzin97);

            }
            catch (Exception)
            {

                textBox7.Text = "Hata!!";
            }
            try
            {
                fDizel = fDizel + (fDizel * Convert.ToDouble(textBox8.Text) / 100);
                fiyatBilgileri[2] = Convert.ToString(fDizel);

            }
            catch (Exception)
            {

                textBox8.Text = "Hata!!";
            }
            try
            {
                fEuroDizel = fEuroDizel + (fEuroDizel * Convert.ToDouble(textBox9.Text) / 100);
                fiyatBilgileri[3] = Convert.ToString(fEuroDizel);

            }
            catch (Exception)
            {

                textBox9.Text = "Hata!!";
            }
            try
            {
                fLpg = fLpg + (fLpg * Convert.ToDouble(textBox10.Text) / 100);
                fiyatBilgileri[4] = Convert.ToString(fLpg);

            }
            catch (Exception)
            {

                textBox10.Text = "Hata!!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyatBilgileri);
            txt_fiyat_oku();
            txt_fiyat_yaz();
        }

        //satış yapma
        private void button3_Click(object sender, EventArgs e)
        {
            sBenzin95 = double.Parse(numericUpDown1.Value.ToString());
            sBenzin97 = double.Parse(numericUpDown2.Value.ToString());
            sDizel = double.Parse(numericUpDown3.Value.ToString());
            sEuroDizel = double.Parse(numericUpDown4.Value.ToString());
            sLpg = double.Parse(numericUpDown5.Value.ToString());

            if(numericUpDown1.Enabled == true)
            {
                dBenzin95 = dBenzin95 - sBenzin95;
                label28.Text = Convert.ToString(sBenzin95 * fBenzin95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                dBenzin97 = dBenzin97 - sBenzin97;
                label28.Text = Convert.ToString(sBenzin97 * fBenzin97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                dDizel = dDizel - sDizel;
                label28.Text = Convert.ToString(sDizel * fDizel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                dEuroDizel = dEuroDizel - sEuroDizel;
                label28.Text = Convert.ToString(sEuroDizel * fBenzin97);
            }
            else if (numericUpDown5.Enabled == true)
            {
                dLpg = dLpg - sLpg;
                label28.Text = Convert.ToString(sLpg * fLpg);
            }

            // satış yapıldıktan sonra depodaki benzinin son değerlerini güncelleme
            depoBilgileri[0] = Convert.ToString(dBenzin95);
            depoBilgileri[1] = Convert.ToString(dBenzin97);
            depoBilgileri[2] = Convert.ToString(dDizel);
            depoBilgileri[3] = Convert.ToString(dEuroDizel);
            depoBilgileri[4] = Convert.ToString(dLpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depoBilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressbar_guncelle();
            numericupdown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Akaryakıt Otomasyonu"; // Forma başlık ekler
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;


            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();

            progressbar_guncelle();

            numericupdown_value();

            string[] yakitTurleri = { "Benzin95", "Benzin97", "Dizel", "Euro Dizel", "LPG" };
            comboBox1.Items.AddRange(yakitTurleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            // Virgülden sonraki ondalık sayısı için
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            // Artış Miktarı Belirleme
            // Artış miktarı ondalıklı olmasını istersek sonuna m koymamız gerekir.
            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            // Dışarıdan veri girişini kapatma
            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

        }
    }
}
