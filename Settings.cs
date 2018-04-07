using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrentDrives
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            // Set the form controls with values.
            textBoxBuildBasePath.Text = currentDrivePlatform.BuildsPath;
            checkBoxRememberVersion.Checked = currentDrivePlatform.RestoreVersion;

            textBoxBLDFile.Text = currentDrivePlatform.BldDirectortyPath + @"\" + currentDrivePlatform.BldFileName;

            textBoxRADDeliveryTool.Text = currentDrivePlatform.Rad2DDeliveryTool;
            textBoxS3DDeliveryTool.Text = currentDrivePlatform.S3DDeliveryTool;

            textBoxTFSAuditTool.Text  = currentDrivePlatform.AuditTool;

            checkBoxGenerateSubstDelete.Checked = currentDrivePlatform.GenerateSubstDelete;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Save the form settings here.
            currentDrivePlatform.BuildsPath = textBoxBuildBasePath.Text;
            currentDrivePlatform.RestoreVersion = checkBoxRememberVersion.Checked;

            string strBLDFile = textBoxBLDFile.Text;

            int posIndex = strBLDFile.LastIndexOf(@"\");

            if (posIndex != -1)
            {
                currentDrivePlatform.BldFileName = strBLDFile.Substring(posIndex + 1);
                currentDrivePlatform.BldDirectortyPath = currentDrivePlatform.Left(strBLDFile, posIndex);

                currentDrivePlatform.Rad2DDeliveryTool= textBoxRADDeliveryTool.Text;
                currentDrivePlatform.S3DDeliveryTool = textBoxS3DDeliveryTool.Text;
                currentDrivePlatform.AuditTool = textBoxTFSAuditTool.Text;
            }

            currentDrivePlatform.GenerateSubstDelete = checkBoxGenerateSubstDelete.Checked;

            Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dlgSts;

            folderBrowserDialog1.Description = "Select the root directory for RAD Builds.";
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (0 < textBoxBuildBasePath.Text.Length)
            {
                folderBrowserDialog1.SelectedPath = textBoxBuildBasePath.Text;
            }
            //else
            //{
            //    folderBrowserDialog1.SelectedPath = Path.GetTempPath();
            //}

            dlgSts = folderBrowserDialog1.ShowDialog(this);

            if (DialogResult.OK == dlgSts)
            {
                textBoxBuildBasePath.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void buttonBLDName_Click(object sender, EventArgs e)
        {
            DialogResult dlgSts;

            openFileDialog1.Filter = "bld files (*.bld)|*.bld|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = currentDrivePlatform.BldDirectortyPath;

            if (0 < textBoxBLDFile.Text.Length)
            {
                openFileDialog1.FileName = textBoxBLDFile.Text;
            }

            dlgSts = openFileDialog1.ShowDialog(this);

            if (DialogResult.OK == dlgSts)
            {
                textBoxBLDFile.Text = openFileDialog1.FileName;
            }
        }

        private void buttonRADTool_Click(object sender, EventArgs e)
        {
            DialogResult dlgSts;

            string strDirectory = "";
            string strFile = textBoxRADDeliveryTool.Text;

            int posIndex = strFile.LastIndexOf(@"\");

            if (posIndex != -1)
            {
                strDirectory = currentDrivePlatform.Left(strFile, posIndex);
                strFile = strFile.Substring(posIndex + 1);
            }

            openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = strDirectory;

            if (0 < strFile.Length)
            {
                openFileDialog1.FileName = strFile;
            }

            dlgSts = openFileDialog1.ShowDialog(this);

            if (DialogResult.OK == dlgSts)
            {
                textBoxRADDeliveryTool.Text = openFileDialog1.FileName;
            }
        }

        private void buttonS3DDeliveryTool_Click(object sender, EventArgs e)
        {
            DialogResult dlgSts;

            string strDirectory = "";
            string strFile = textBoxS3DDeliveryTool.Text;

            int posIndex = strFile.LastIndexOf(@"\");

            if (posIndex != -1)
            {
                strDirectory = currentDrivePlatform.Left(strFile, posIndex);
                strFile = strFile.Substring(posIndex + 1);
            }

            openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = strDirectory;

            if (0 < strFile.Length)
            {
                openFileDialog1.FileName = strFile;
            }

            dlgSts = openFileDialog1.ShowDialog(this);

            if (DialogResult.OK == dlgSts)
            {
                textBoxS3DDeliveryTool.Text = openFileDialog1.FileName;
            }

        }

        private void buttonTFSAuditTool_Click(object sender, EventArgs e)
        {
            DialogResult dlgSts;

            string strDirectory = "";
            string strFile = textBoxTFSAuditTool.Text;

            int posIndex = strFile.LastIndexOf(@"\");

            if (posIndex != -1)
            {
                strDirectory = currentDrivePlatform.Left(strFile, posIndex);
                strFile = strFile.Substring(posIndex + 1);
            }

            openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = strDirectory;

            if (0 < strFile.Length)
            {
                openFileDialog1.FileName = strFile;
            }

            dlgSts = openFileDialog1.ShowDialog(this);

            if (DialogResult.OK == dlgSts)
            {
                textBoxTFSAuditTool.Text = openFileDialog1.FileName;
            }


        }
    }
}

