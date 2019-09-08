using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolTipUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Determine ToolTip Feature
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "Uyarı!";
            toolTip1.AutomaticDelay = 200;
            toolTip1.AutoPopDelay = 3000;

            toolTip2.ToolTipIcon = ToolTipIcon.Info;
            toolTip2.ToolTipTitle = "Bilgilendirme.";
            toolTip2.AutomaticDelay = 200;
            toolTip2.AutoPopDelay = 2000;

            // Tricks text
            toolTip1.SetToolTip(this.textBox1, "Kişisel Bilgiler");
            toolTip1.SetToolTip(this.textBox2, "Kullanıcı Adı 8 karakter olmalı");
            toolTip1.SetToolTip(this.textBox3, "Şifre harf, sayı ve özel karakter içermelidir.");
            toolTip1.SetToolTip(this.textBox4, "Lütfen şifrenizi doğrulayın.");
            toolTip2.SetToolTip(this.textBox5, "Cep telefonu bilgisi zorunlu değil.");
        }
    }
}
