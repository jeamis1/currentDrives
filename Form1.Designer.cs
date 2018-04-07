namespace CurrentDrives
{
    partial class FormDrives
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDrives));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDeleteBuild = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtontoolStripButtonRADDeliveryTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonS3DDeliveryTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripPlatformCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSetDriveScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPatcher = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTFSAuditTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRegEngine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSettings = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.popupdnbtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(570, 240);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDeleteBuild,
            this.toolStripSeparator3,
            this.toolStripButtontoolStripButtonRADDeliveryTool,
            this.toolStripButtonS3DDeliveryTool,
            this.toolStripButtonRefresh,
            this.toolStripPlatformCombo,
            this.toolStripButton1,
            this.toolStripSetDriveScript,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripPatcher,
            this.toolStripButton2,
            this.toolStripButtonTFSAuditTool,
            this.toolStripSeparator4,
            this.toolStripButtonRegEngine,
            this.toolStripSeparator2,
            this.toolStripSettings});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(567, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDeleteBuild
            // 
            this.toolStripButtonDeleteBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteBuild.Image = global::CurrentDrives.Properties.Resources.WipeBuild1;
            this.toolStripButtonDeleteBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteBuild.Name = "toolStripButtonDeleteBuild";
            this.toolStripButtonDeleteBuild.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonDeleteBuild.Text = "Delete Build on Machine";
            this.toolStripButtonDeleteBuild.ToolTipText = "Delete Build on Machine";
            this.toolStripButtonDeleteBuild.Click += new System.EventHandler(this.toolStripButtonDeleteBuild_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtontoolStripButtonRADDeliveryTool
            // 
            this.toolStripButtontoolStripButtonRADDeliveryTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtontoolStripButtonRADDeliveryTool.Image = global::CurrentDrives.Properties.Resources.RADDelivery;
            this.toolStripButtontoolStripButtonRADDeliveryTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtontoolStripButtonRADDeliveryTool.Name = "toolStripButtontoolStripButtonRADDeliveryTool";
            this.toolStripButtontoolStripButtonRADDeliveryTool.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtontoolStripButtonRADDeliveryTool.Text = "RADDeliveryTool";
            this.toolStripButtontoolStripButtonRADDeliveryTool.Click += new System.EventHandler(this.toolStripButtontoolStripButtonRADDeliveryTool_Click);
            // 
            // toolStripButtonS3DDeliveryTool
            // 
            this.toolStripButtonS3DDeliveryTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonS3DDeliveryTool.Image = global::CurrentDrives.Properties.Resources.S3DDel1;
            this.toolStripButtonS3DDeliveryTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonS3DDeliveryTool.Name = "toolStripButtonS3DDeliveryTool";
            this.toolStripButtonS3DDeliveryTool.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonS3DDeliveryTool.Text = "S3DDeliveryTool";
            this.toolStripButtonS3DDeliveryTool.Click += new System.EventHandler(this.toolStripButtonS3DDeliveryTool_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::CurrentDrives.Properties.Resources.refreshBld1;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRefresh.Text = "toolStripButton4";
            this.toolStripButtonRefresh.ToolTipText = "Refresh Build Information";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripPlatformCombo
            // 
            this.toolStripPlatformCombo.Name = "toolStripPlatformCombo";
            this.toolStripPlatformCombo.Size = new System.Drawing.Size(121, 27);
            this.toolStripPlatformCombo.Click += new System.EventHandler(this.toolStripPlatformCombo_Click);
            this.toolStripPlatformCombo.TextChanged += new System.EventHandler(this.toolStripPlatformCombo_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CurrentDrives.Properties.Resources.lightning;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Set Drives";
            this.toolStripButton1.ToolTipText = "Set Drives";
            this.toolStripButton1.CheckedChanged += new System.EventHandler(this.toolStripButton1_CheckedChanged);
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSetDriveScript
            // 
            this.toolStripSetDriveScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSetDriveScript.Image = global::CurrentDrives.Properties.Resources.SetDrives;
            this.toolStripSetDriveScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSetDriveScript.Name = "toolStripSetDriveScript";
            this.toolStripSetDriveScript.Size = new System.Drawing.Size(24, 24);
            this.toolStripSetDriveScript.Text = "Generate set drive script";
            this.toolStripSetDriveScript.Click += new System.EventHandler(this.toolStripSetDriveScript_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::CurrentDrives.Properties.Resources.CleanBuild;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "Clear Build";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripPatcher
            // 
            this.toolStripPatcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPatcher.Image = global::CurrentDrives.Properties.Resources.Patcher;
            this.toolStripPatcher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPatcher.Name = "toolStripPatcher";
            this.toolStripPatcher.Size = new System.Drawing.Size(24, 24);
            this.toolStripPatcher.Text = "Patcher ";
            this.toolStripPatcher.Click += new System.EventHandler(this.toolStripPatcher_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::CurrentDrives.Properties.Resources.BuildTool1;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "Launch BuildTool";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButtonTFSAuditTool
            // 
            this.toolStripButtonTFSAuditTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTFSAuditTool.Image = global::CurrentDrives.Properties.Resources.TFSAudit;
            this.toolStripButtonTFSAuditTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTFSAuditTool.Name = "toolStripButtonTFSAuditTool";
            this.toolStripButtonTFSAuditTool.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonTFSAuditTool.Text = "TFSAuditTool";
            this.toolStripButtonTFSAuditTool.Click += new System.EventHandler(this.toolStripButtonTFSAuditTool_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonRegEngine
            // 
            this.toolStripButtonRegEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRegEngine.Image = global::CurrentDrives.Properties.Resources.RegEngine;
            this.toolStripButtonRegEngine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRegEngine.Name = "toolStripButtonRegEngine";
            this.toolStripButtonRegEngine.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRegEngine.Text = "toolStripButton4";
            this.toolStripButtonRegEngine.ToolTipText = "S3D Registration tool";
            this.toolStripButtonRegEngine.Click += new System.EventHandler(this.toolStripButtonRegEngine_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSettings.Image = global::CurrentDrives.Properties.Resources.Settings;
            this.toolStripSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(24, 24);
            this.toolStripSettings.Text = "Settings ";
            this.toolStripSettings.ToolTipText = "Settings";
            this.toolStripSettings.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(250, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar.Visible = false;
            // 
            // popupdnbtn
            // 
            this.popupdnbtn.AutoSize = true;
            this.popupdnbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.popupdnbtn.Image = global::CurrentDrives.Properties.Resources.Expand2;
            this.popupdnbtn.Location = new System.Drawing.Point(536, 0);
            this.popupdnbtn.Margin = new System.Windows.Forms.Padding(1);
            this.popupdnbtn.Name = "popupdnbtn";
            this.popupdnbtn.Size = new System.Drawing.Size(30, 30);
            this.popupdnbtn.TabIndex = 2;
            this.popupdnbtn.UseVisualStyleBackColor = true;
            this.popupdnbtn.Click += new System.EventHandler(this.popupdnbtn_Click);
            // 
            // FormDrives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(567, 261);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.popupdnbtn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDrives";
            this.Text = "RAD Platform Drives";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FormDrives_ClientSizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripPlatformCombo;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripSettings;
        private System.Windows.Forms.Button popupdnbtn;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtontoolStripButtonRADDeliveryTool;
        private System.Windows.Forms.ToolStripButton toolStripButtonS3DDeliveryTool;
        private System.Windows.Forms.ToolStripButton toolStripButtonTFSAuditTool;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteBuild;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripSetDriveScript;
        private System.Windows.Forms.ToolStripButton toolStripPatcher;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonRegEngine;
    }
}

