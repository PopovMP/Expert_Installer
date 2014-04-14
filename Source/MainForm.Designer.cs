namespace ExpertInstaller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblAnnounce = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.tbxOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkMsRedist = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itmSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAnnounce
            // 
            this.lblAnnounce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnnounce.Location = new System.Drawing.Point(12, 38);
            this.lblAnnounce.Name = "lblAnnounce";
            this.lblAnnounce.Size = new System.Drawing.Size(341, 40);
            this.lblAnnounce.TabIndex = 2;
            this.lblAnnounce.Text = "Exper Installer searches MT4 terminals and installs \"MT4-FST Expert.ex4\" and \"MT4" +
    "-FST Library.dll\".";
            // 
            // btnInstall
            // 
            this.btnInstall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstall.Location = new System.Drawing.Point(65, 192);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(225, 35);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install MT4 Expert files";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.Install_Click);
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(15, 248);
            this.tbxOutput.Multiline = true;
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.Size = new System.Drawing.Size(338, 68);
            this.tbxOutput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(62, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Make sure MS VC++ 2010 is installed.\r\nIf not, download and install it:";
            // 
            // linkMsRedist
            // 
            this.linkMsRedist.AutoSize = true;
            this.linkMsRedist.Location = new System.Drawing.Point(62, 144);
            this.linkMsRedist.Name = "linkMsRedist";
            this.linkMsRedist.Size = new System.Drawing.Size(228, 15);
            this.linkMsRedist.TabIndex = 9;
            this.linkMsRedist.TabStop = true;
            this.linkMsRedist.Tag = "http://www.microsoft.com/en-us/download/details.aspx?id=5555";
            this.linkMsRedist.Text = "Microsoft Visual C++ 2010 Redistributable";
            this.linkMsRedist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkMsRedist_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSupport,
            this.itmHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(368, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // itmSupport
            // 
            this.itmSupport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.itmSupport.Name = "itmSupport";
            this.itmSupport.Size = new System.Drawing.Size(99, 20);
            this.itmSupport.Tag = "http://forexsb.com/forum/";
            this.itmSupport.Text = "Support Forum";
            this.itmSupport.Click += new System.EventHandler(this.Support_Click);
            // 
            // itmHelp
            // 
            this.itmHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.itmHelp.Name = "itmHelp";
            this.itmHelp.Size = new System.Drawing.Size(105, 20);
            this.itmHelp.Tag = "http://forexsb.com/wiki/fsbpro/manual/expert_installer";
            this.itmHelp.Text = "Installation Help";
            this.itmHelp.Click += new System.EventHandler(this.Help_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(27, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "1.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(27, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 30);
            this.label4.TabIndex = 12;
            this.label4.Text = "2.";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(248, 339);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 386);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkMsRedist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxOutput);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.lblAnnounce);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Expert Installer";
            this.TopMost = true;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnnounce;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.TextBox tbxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkMsRedist;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itmSupport;
        private System.Windows.Forms.ToolStripMenuItem itmHelp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
    }
}

