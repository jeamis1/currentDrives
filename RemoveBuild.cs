using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrentDrives
{
    public partial class RemoveBuild : Form
    {
        // private ProgressBar progressBar = null;
        private StringCollection filesToDelete;
       // private StringCollection directoryToDelete;

       // public ProgressBar pBar
        public ToolStripProgressBar pBar
        {
            get;
            set;
        }

        public ToolStripLabel pLabel
        {
            get;
            set;
        }

        public RemoveBuild()
        {
            InitializeComponent();

            // Load the builds that can be removed (All builds except the current build.)
            currentDrivePlatform.LoadComboBox(checkedBuildsListBox);
        }

        private void GetFilesInDirectoryTree(string directoryOfBuild)
        {
            foreach (var file in Directory.GetFiles(directoryOfBuild))
            {
                filesToDelete.Add(file);
            }

            foreach (var directory in Directory.GetDirectories(directoryOfBuild))
            {
                GetFilesInDirectoryTree(directory);
            }

        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        private void DeleteBuild(string directory)
        {
            FileAttributes attributes;
            filesToDelete = new StringCollection();
           // directoryToDelete = new StringCollection();

            GetFilesInDirectoryTree(directory);

            pBar.Maximum = filesToDelete.Count;
            pBar.Value = 0;
            pBar.Visible = true;
            foreach (string fileName in filesToDelete)
            {
                attributes = File.GetAttributes(fileName);

                pBar.Value++;
                
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);

                File.SetAttributes(fileName, attributes);

                try
                {
                    File.Delete(fileName);
                    pLabel.Text = "Deleted " + pBar.Value.ToString() + " files. ";
                   // System.Threading.Thread.Sleep(100);

                }
                catch (IOException eIO)
                {
                    DialogResult dr =  MessageBox.Show("Exception occurred : " + eIO.Message + " Continue ? ", "RAD Platform Drives", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        break;
                    }
                    continue;
                }
            }
            pBar.Visible = false;
            filesToDelete.Clear();
            filesToDelete = null;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            version v;
            string buildVersion = "";
            string buildPath = "";
            // Process the builds selected.
            foreach (object itemChecked in checkedBuildsListBox.CheckedItems)
            {

                // Use the IndexOf method to get the index of an item.
                //MessageBox.Show("Item with title: \"" + itemChecked.ToString() +
                //                "\", is checked. Checked state is: " +
                //                checkedBuildsListBox.GetItemCheckState(checkedBuildsListBox.Items.IndexOf(itemChecked)).ToString() + ".");

                buildVersion = itemChecked.ToString();
                v = currentDrivePlatform.FindVersion(buildVersion);
                buildPath = v.path;
               // MessageBox.Show("Version = " + buildVersion + "  buildPath = " + buildPath);


                // Remove the files and directories.
                try
                {
                    DeleteBuild(buildPath);
                    Directory.Delete(buildPath, true);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }

            }


            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
