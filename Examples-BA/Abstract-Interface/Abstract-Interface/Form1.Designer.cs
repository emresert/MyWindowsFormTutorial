namespace Abstract_Interface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboSilahlar = new System.Windows.Forms.ComboBox();
            this.btnGoster = new System.Windows.Forms.Button();
            this.lblOzellik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboSilahlar
            // 
            this.cboSilahlar.FormattingEnabled = true;
            this.cboSilahlar.Location = new System.Drawing.Point(45, 25);
            this.cboSilahlar.Name = "cboSilahlar";
            this.cboSilahlar.Size = new System.Drawing.Size(121, 21);
            this.cboSilahlar.TabIndex = 0;
            // 
            // btnGoster
            // 
            this.btnGoster.Location = new System.Drawing.Point(220, 25);
            this.btnGoster.Name = "btnGoster";
            this.btnGoster.Size = new System.Drawing.Size(75, 23);
            this.btnGoster.TabIndex = 1;
            this.btnGoster.Text = "Göster";
            this.btnGoster.UseVisualStyleBackColor = true;
            // 
            // lblOzellik
            // 
            this.lblOzellik.AutoSize = true;
            this.lblOzellik.Location = new System.Drawing.Point(42, 81);
            this.lblOzellik.Name = "lblOzellik";
            this.lblOzellik.Size = new System.Drawing.Size(35, 13);
            this.lblOzellik.TabIndex = 2;
            this.lblOzellik.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOzellik);
            this.Controls.Add(this.btnGoster);
            this.Controls.Add(this.cboSilahlar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSilahlar;
        private System.Windows.Forms.Button btnGoster;
        private System.Windows.Forms.Label lblOzellik;
    }
}

