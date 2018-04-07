namespace CurrentDrives
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxRememberVersion = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxBuildBasePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonBLDName = new System.Windows.Forms.Button();
            this.labelBLDFile = new System.Windows.Forms.Label();
            this.textBoxBLDFile = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTFSAuditTool = new System.Windows.Forms.Button();
            this.textBoxTFSAuditTool = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonS3DDeliveryTool = new System.Windows.Forms.Button();
            this.textBoxS3DDeliveryTool = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRADTool = new System.Windows.Forms.Button();
            this.textBoxRADDeliveryTool = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxGenerateSubstDelete = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(521, 203);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(513, 177);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxRememberVersion);
            this.groupBox2.Location = new System.Drawing.Point(10, 118);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(492, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Behaviors";
            // 
            // checkBoxRememberVersion
            // 
            this.checkBoxRememberVersion.AutoSize = true;
            this.checkBoxRememberVersion.Location = new System.Drawing.Point(20, 23);
            this.checkBoxRememberVersion.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxRememberVersion.Name = "checkBoxRememberVersion";
            this.checkBoxRememberVersion.Size = new System.Drawing.Size(238, 17);
            this.checkBoxRememberVersion.TabIndex = 0;
            this.checkBoxRememberVersion.Text = "Remember build version and set it on startup.";
            this.checkBoxRememberVersion.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Controls.Add(this.textBoxBuildBasePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(493, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(429, 40);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(1);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonBrowse.Size = new System.Drawing.Size(50, 24);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxBuildBasePath
            // 
            this.textBoxBuildBasePath.Location = new System.Drawing.Point(20, 44);
            this.textBoxBuildBasePath.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxBuildBasePath.Name = "textBoxBuildBasePath";
            this.textBoxBuildBasePath.Size = new System.Drawing.Size(403, 20);
            this.textBoxBuildBasePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Builds Base Path:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage2.Size = new System.Drawing.Size(513, 177);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Build";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonBLDName);
            this.groupBox3.Controls.Add(this.labelBLDFile);
            this.groupBox3.Controls.Add(this.textBoxBLDFile);
            this.groupBox3.Location = new System.Drawing.Point(8, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 73);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Build File to Open";
            // 
            // buttonBLDName
            // 
            this.buttonBLDName.Location = new System.Drawing.Point(430, 34);
            this.buttonBLDName.Name = "buttonBLDName";
            this.buttonBLDName.Size = new System.Drawing.Size(50, 24);
            this.buttonBLDName.TabIndex = 2;
            this.buttonBLDName.Text = "B&rowse";
            this.buttonBLDName.UseVisualStyleBackColor = true;
            this.buttonBLDName.Click += new System.EventHandler(this.buttonBLDName_Click);
            // 
            // labelBLDFile
            // 
            this.labelBLDFile.AutoSize = true;
            this.labelBLDFile.Location = new System.Drawing.Point(15, 19);
            this.labelBLDFile.Name = "labelBLDFile";
            this.labelBLDFile.Size = new System.Drawing.Size(54, 13);
            this.labelBLDFile.TabIndex = 1;
            this.labelBLDFile.Text = "&Builld File:";
            // 
            // textBoxBLDFile
            // 
            this.textBoxBLDFile.Location = new System.Drawing.Point(18, 35);
            this.textBoxBLDFile.Name = "textBoxBLDFile";
            this.textBoxBLDFile.Size = new System.Drawing.Size(404, 20);
            this.textBoxBLDFile.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(513, 177);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tools";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTFSAuditTool);
            this.groupBox4.Controls.Add(this.textBoxTFSAuditTool);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.buttonS3DDeliveryTool);
            this.groupBox4.Controls.Add(this.textBoxS3DDeliveryTool);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.buttonRADTool);
            this.groupBox4.Controls.Add(this.textBoxRADDeliveryTool);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(496, 165);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tools Locations";
            // 
            // buttonTFSAuditTool
            // 
            this.buttonTFSAuditTool.Location = new System.Drawing.Point(428, 133);
            this.buttonTFSAuditTool.Name = "buttonTFSAuditTool";
            this.buttonTFSAuditTool.Size = new System.Drawing.Size(50, 24);
            this.buttonTFSAuditTool.TabIndex = 8;
            this.buttonTFSAuditTool.Text = "Browse";
            this.buttonTFSAuditTool.UseVisualStyleBackColor = true;
            this.buttonTFSAuditTool.Click += new System.EventHandler(this.buttonTFSAuditTool_Click);
            // 
            // textBoxTFSAuditTool
            // 
            this.textBoxTFSAuditTool.Location = new System.Drawing.Point(18, 134);
            this.textBoxTFSAuditTool.Name = "textBoxTFSAuditTool";
            this.textBoxTFSAuditTool.Size = new System.Drawing.Size(404, 20);
            this.textBoxTFSAuditTool.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "TFS Audit Tool:";
            // 
            // buttonS3DDeliveryTool
            // 
            this.buttonS3DDeliveryTool.Location = new System.Drawing.Point(428, 77);
            this.buttonS3DDeliveryTool.Name = "buttonS3DDeliveryTool";
            this.buttonS3DDeliveryTool.Size = new System.Drawing.Size(50, 24);
            this.buttonS3DDeliveryTool.TabIndex = 5;
            this.buttonS3DDeliveryTool.Text = "Browse";
            this.buttonS3DDeliveryTool.UseVisualStyleBackColor = true;
            this.buttonS3DDeliveryTool.Click += new System.EventHandler(this.buttonS3DDeliveryTool_Click);
            // 
            // textBoxS3DDeliveryTool
            // 
            this.textBoxS3DDeliveryTool.Location = new System.Drawing.Point(18, 81);
            this.textBoxS3DDeliveryTool.Name = "textBoxS3DDeliveryTool";
            this.textBoxS3DDeliveryTool.Size = new System.Drawing.Size(404, 20);
            this.textBoxS3DDeliveryTool.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "S3D Delivery Tool:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "RAD Delivery Tool:";
            // 
            // buttonRADTool
            // 
            this.buttonRADTool.Location = new System.Drawing.Point(428, 29);
            this.buttonRADTool.Name = "buttonRADTool";
            this.buttonRADTool.Size = new System.Drawing.Size(50, 24);
            this.buttonRADTool.TabIndex = 1;
            this.buttonRADTool.Text = "Browse";
            this.buttonRADTool.UseVisualStyleBackColor = true;
            this.buttonRADTool.Click += new System.EventHandler(this.buttonRADTool_Click);
            // 
            // textBoxRADDeliveryTool
            // 
            this.textBoxRADDeliveryTool.Location = new System.Drawing.Point(18, 33);
            this.textBoxRADDeliveryTool.Name = "textBoxRADDeliveryTool";
            this.textBoxRADDeliveryTool.Size = new System.Drawing.Size(404, 20);
            this.textBoxRADDeliveryTool.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(358, 214);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(1);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(76, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(436, 214);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxGenerateSubstDelete);
            this.groupBox5.Location = new System.Drawing.Point(8, 96);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(497, 77);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Optional Behaviors";
            // 
            // checkBoxGenerateSubstDelete
            // 
            this.checkBoxGenerateSubstDelete.AutoSize = true;
            this.checkBoxGenerateSubstDelete.Location = new System.Drawing.Point(18, 19);
            this.checkBoxGenerateSubstDelete.Name = "checkBoxGenerateSubstDelete";
            this.checkBoxGenerateSubstDelete.Size = new System.Drawing.Size(310, 17);
            this.checkBoxGenerateSubstDelete.TabIndex = 0;
            this.checkBoxGenerateSubstDelete.Text = "Generate subst <drive:> /d regardless of directory existance.";
            this.checkBoxGenerateSubstDelete.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 243);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxRememberVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxBuildBasePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonBLDName;
        private System.Windows.Forms.Label labelBLDFile;
        private System.Windows.Forms.TextBox textBoxBLDFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxRADDeliveryTool;
        private System.Windows.Forms.Button buttonRADTool;
        private System.Windows.Forms.TextBox textBoxS3DDeliveryTool;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonS3DDeliveryTool;
        private System.Windows.Forms.TextBox textBoxTFSAuditTool;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonTFSAuditTool;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxGenerateSubstDelete;
    }
}