namespace Otopark_Otomasyonu
{
    partial class FormSeri
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelEdit1 = new DevExpress.DXperience.Demos.DescriptionLabel();
            this.descriptionLabel1 = new DevExpress.DXperience.Demos.DescriptionLabel();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(106, 90);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Ekle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textBoxEdit1
            // 
            this.textBoxEdit1.Location = new System.Drawing.Point(92, 54);
            this.textBoxEdit1.Name = "textBoxEdit1";
            this.textBoxEdit1.Size = new System.Drawing.Size(125, 22);
            this.textBoxEdit1.TabIndex = 10;
            // 
            // labelEdit1
            // 
            this.labelEdit1.Location = new System.Drawing.Point(42, 29);
            this.labelEdit1.Name = "labelEdit1";
            this.labelEdit1.Size = new System.Drawing.Size(35, 16);
            this.labelEdit1.TabIndex = 9;
            this.labelEdit1.Text = "Marka";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.Location = new System.Drawing.Point(54, 57);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(23, 16);
            this.descriptionLabel1.TabIndex = 11;
            this.descriptionLabel1.Text = "Seri";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(92, 26);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(125, 22);
            this.comboBoxEdit1.TabIndex = 12;
            // 
            // FormSeri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(428, 221);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.descriptionLabel1);
            this.Controls.Add(this.textBoxEdit1);
            this.Controls.Add(this.labelEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "FormSeri";
            this.Text = "FormSeri";
            this.Load += new System.EventHandler(this.FormSeri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textBoxEdit1;
        private DevExpress.DXperience.Demos.DescriptionLabel labelEdit1;
        private DevExpress.DXperience.Demos.DescriptionLabel descriptionLabel1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
    }
}