namespace ECoS
{
    partial class AboutForm
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
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.developersLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.ecosLinkLabel = new System.Windows.Forms.LinkLabel();
            this.horizontalBarPictureBox1 = new System.Windows.Forms.PictureBox();
            this.horizontalBarPictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalBarPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalBarPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPictureBox.ErrorImage = null;
            this.logoPictureBox.Image = global::ECoS.Properties.Resources.ECoSLogo_256;
            this.logoPictureBox.InitialImage = null;
            this.logoPictureBox.Location = new System.Drawing.Point(40, 38);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(160, 154);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(220, 48);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(247, 91);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "ECoS";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(240, 144);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(163, 30);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "Version 0.0.1";
            // 
            // developersLabel
            // 
            this.developersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.developersLabel.Location = new System.Drawing.Point(40, 269);
            this.developersLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.developersLabel.Name = "developersLabel";
            this.developersLabel.Size = new System.Drawing.Size(400, 167);
            this.developersLabel.TabIndex = 3;
            this.developersLabel.Text = "Developers: Nuo Chen, Larissa Gao, Tianning Li, Connor Moen, Patrick Render, Ri" +
                     "chard Tran, Haoyuan Xia, Bowen Xiao, Steve Yang";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.Location = new System.Drawing.Point(35, 488);
            this.copyrightLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(360, 77);
            this.copyrightLabel.TabIndex = 4;
            this.copyrightLabel.Text = "Copyright © 2019 UW SEAL. All rights reserved.";
            // 
            // ecosLinkLabel
            // 
            this.ecosLinkLabel.ActiveLinkColor = System.Drawing.Color.Black;
            this.ecosLinkLabel.AutoSize = true;
            this.ecosLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ecosLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.ecosLinkLabel.Location = new System.Drawing.Point(35, 608);
            this.ecosLinkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ecosLinkLabel.Name = "ecosLinkLabel";
            this.ecosLinkLabel.Size = new System.Drawing.Size(187, 30);
            this.ecosLinkLabel.TabIndex = 5;
            this.ecosLinkLabel.TabStop = true;
            this.ecosLinkLabel.Text = "www.ecos.com";
            this.ecosLinkLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.ecosLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ecosLinkLabel_LinkClicked);
            // 
            // horizontalBarPictureBox1
            // 
            this.horizontalBarPictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.horizontalBarPictureBox1.Location = new System.Drawing.Point(40, 231);
            this.horizontalBarPictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.horizontalBarPictureBox1.Name = "horizontalBarPictureBox1";
            this.horizontalBarPictureBox1.Size = new System.Drawing.Size(400, 2);
            this.horizontalBarPictureBox1.TabIndex = 7;
            this.horizontalBarPictureBox1.TabStop = false;
            // 
            // horizontalBarPictureBox2
            // 
            this.horizontalBarPictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.horizontalBarPictureBox2.Location = new System.Drawing.Point(40, 442);
            this.horizontalBarPictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.horizontalBarPictureBox2.Name = "horizontalBarPictureBox2";
            this.horizontalBarPictureBox2.Size = new System.Drawing.Size(400, 2);
            this.horizontalBarPictureBox2.TabIndex = 8;
            this.horizontalBarPictureBox2.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 687);
            this.Controls.Add(this.horizontalBarPictureBox2);
            this.Controls.Add(this.horizontalBarPictureBox1);
            this.Controls.Add(this.ecosLinkLabel);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.developersLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About ECoS";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalBarPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalBarPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label developersLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.LinkLabel ecosLinkLabel;
        private System.Windows.Forms.PictureBox horizontalBarPictureBox1;
        private System.Windows.Forms.PictureBox horizontalBarPictureBox2;
    }
}
