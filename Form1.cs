using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Principal;


namespace CurrentDrives
{
    public partial class FormDrives : Form
    {
        private bool bCollapseExpand = true;
        static DriveInfo[] allDrives;// = DriveInfo.GetDrives();
        public currentDrivePlatform platform;// = new currentDrivePlatform();
        public string selectedVersion = null;
        public int formHeight = 500;
        public int toggleHeight = 500;
        private bool AllInitialized = false;
        private Process radDeliveryTool;
        private Process s3dDeliveryTool;
        private bool RunningAsAdministrator = false;

        private Boolean IsProcessRunningInAdmin()
        {
            Boolean bIsAdmin = false;
            
            if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                bIsAdmin = true;
            }
            return bIsAdmin;
        }
        public FormDrives()
        {
            // Get the current process.
           // Process currentProcess = Process.GetCurrentProcess();


            InitializeComponent();
            
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);

            platform = new currentDrivePlatform();

            currentDrivePlatform.LoadPlatFormTableByEnumerateFiles();

            // load the form combo box 
            currentDrivePlatform.LoadComboBox(toolStripPlatformCombo);
            formHeight = 500;
            Size = new Size(Width, formHeight);

            RunningAsAdministrator = IsProcessRunningInAdmin();

            if (RunningAsAdministrator)
            {
                treeView1.BackColor = Color.Beige;
                this.BackColor = Color.DarkGray;
                this.ForeColor = Color.White;

                toolStrip1.BackColor = Color.DarkGray;
        //        toolStrip1.ForeColor = Color.Black;
                
                statusStrip1.BackColor = Color.DarkGray;

                //foreach (ToolStripItem c in toolStrip1.Items)
                //{
                //    currentDrivePlatform.UpdateColorControls(c, Color.DarkGray, Color.Black);
                //}

                //foreach (Control c in Controls)
                //{
                //    currentDrivePlatform.UpdateColorControls(c, Color.DarkGray, Color.White);
                //}
            }
            
            toolStripPlatformCombo.Text = currentDrivePlatform.Version;

            treeView1.Location = new Point(0, toolStrip1.Location.Y + toolStrip1.Height);
            treeView1.Size = new Size(treeView1.Size.Width, formHeight - (toolStrip1.Location.Y + toolStrip1.Height + 40));
            treeView1.Update();

            toolStripStatusLabel1.Text = "Drive Loaded Time : " + currentDrivePlatform.loadVersionTableElapsedTime;
            Application.EnableVisualStyles();
           // currentProcess

            AllInitialized = true;
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);

        /// <summary>
        /// DEtermine if the drive is a substituted drive and return the path assigned to the drive.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="realPath"></param>
        /// <returns></returns>
        public static bool IsSubstedPath(string path, out string realPath)
        {
            StringBuilder pathInformation = new StringBuilder(250);
            string driveLetter = null;
            uint winApiResult = 0;

            realPath = null;

            try
            {
                // Get the drive letter of the path
                driveLetter = Path.GetPathRoot(path).Replace("\\", "");
            }
            catch (ArgumentException)
            {
                return false;
                //<------------------
            }

            winApiResult = QueryDosDevice(driveLetter, pathInformation, 250);

            if (winApiResult == 0)
            {
                int lastWinError = Marshal.GetLastWin32Error(); // here is the reason why it fails - not used at the moment!

                return false;
                //<-----------------
            }

            // If drive is substed, the result will be in the format of "\??\C:\RealPath\".
            if (pathInformation.ToString().StartsWith("\\??\\"))
            {
                // Strip the \??\ prefix.
                string realRoot = pathInformation.ToString().Remove(0, 4);

                // add backshlash if not present
                realRoot += pathInformation.ToString().EndsWith(@"\") ? "" : @"\";

                //Combine the paths.
                realPath = Path.Combine(realRoot, path.Replace(Path.GetPathRoot(path), ""));

                return true;
                //<--------------
            }

            realPath = path;

            return false;
        }

        private string GetCurrentSubstituteDriveVersion()
        {
            string currentVersion = "";
            DriveInfo[] allDrives;
            //string CurrentDrive;
            string label = null;
            string realPath = null;
            bool isSubst = false;
            string pathRoot = Path.GetPathRoot(Environment.CurrentDirectory);

            allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                System.IO.DriveType driveType = d.DriveType;
                //CurrentDrive = "";
                //if (d.Name == pathRoot)
                //{
                //    CurrentDrive = " <Current Drive> ";

                //}

                label = d.IsReady ? String.Format("{0}", d.VolumeLabel) : null;

                isSubst = IsSubstedPath(d.Name, out realPath);

                if (isSubst)
                {
                    currentVersion = DetermineCurrentVersion(realPath);
                    break;
                }

            }

            return currentVersion;
        }


        private void LoadTree()
        {
            TreeNode node = null;
            TreeNode sysnode = null;
            string pathRoot = Path.GetPathRoot(Environment.CurrentDirectory);
            string CurrentDrive = "";
            string label = null;
            string realPath = null;
            bool isSubst = false;
            string stringSubst;

            treeView1.UseWaitCursor = true;
            treeView1.Nodes.Clear();
            allDrives = DriveInfo.GetDrives();
            sysnode = treeView1.Nodes.Add("<System>", "<System>");
            foreach (DriveInfo d in allDrives)
            {
                System.IO.DriveType driveType = d.DriveType;
                CurrentDrive = "";
                if (d.Name == pathRoot)
                {
                    CurrentDrive = " <Current Drive> ";

                }

                label = d.IsReady ? String.Format("{0}", d.VolumeLabel) : null;

                isSubst = IsSubstedPath(d.Name, out realPath);
                stringSubst = "";
                if (isSubst)
                {
                    if (selectedVersion == null)
                    {
                        selectedVersion = DetermineCurrentVersion(realPath);
                        toolStripPlatformCombo.Text = selectedVersion;

                    }

                    stringSubst = " - <Substituted drive>";
                }

                node = sysnode.Nodes.Add(d.Name, d.Name + CurrentDrive + stringSubst);
                if (node != null)
                {
                    DirectoryInfo dir = d.RootDirectory;

                    stringSubst = "";

                    if (isSubst)
                    {
                        stringSubst = "<Substituted Path = " + realPath + ">";
                        node.Nodes.Add(stringSubst);
                    }

                    if (label == null)
                    {
                        node.Nodes.Add("Drive Type: " + driveType.ToString());
                    }
                    else
                    {
                        node.Nodes.Add("Drive Type: " + driveType.ToString() + " [ " + label + " ] ");
                    }

                    //if (isSubst == false)
                    //{
                    //    node.Nodes.Add("Total Available Space:" + d.AvailableFreeSpace.ToString());
                    //    node.Nodes.Add("Total Total Space:" + d.TotalSize.ToString());
                    //}
                }
            }

            treeView1.ExpandAll();
            treeView1.UseWaitCursor = false;
        }

        private string DetermineCurrentVersion(string realPath)
        {
            string strVersion = null;

            strVersion = currentDrivePlatform.GetVersionInPath(realPath);

            return strVersion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strCurrentVersion = GetCurrentSubstituteDriveVersion();
            
            if ((currentDrivePlatform.RestoreVersion) && (currentDrivePlatform.Version.Length > 0) && (strCurrentVersion != currentDrivePlatform.Version))
            {

                SetSubstituteDrives(currentDrivePlatform.Version);
            }
            else if ((strCurrentVersion != null) && (strCurrentVersion.Length > 0))
            {
                String admin = "";
                RunningAsAdministrator = IsProcessRunningInAdmin();
                if (RunningAsAdministrator)
                {
                    admin = " {Running As Administrator}";
                }

                this.Text = "RAD Platform Drives [" + strCurrentVersion + "]" + admin;
            }

            LoadTree();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        //  LoadTree();  // this is where you do your magic
                        break;
                    case UsbNotification.DbtDevicearrival:
                        LoadTree();  // this is where you do your magic
                        break;
                }
            }
        }

        internal static class UsbNotification
        {
            public const int DbtDevicearrival = 0x8000; // system detected a new device        
            public const int DbtDeviceremovecomplete = 0x8004; // device is gone      
            public const int WmDevicechange = 0x0219; // device change event      
            private const int DbtDevtypDeviceinterface = 5;
            private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
            private static IntPtr notificationHandle;

            /// <summary>
            /// Registers a window to receive notifications when USB devices are plugged or unplugged.
            /// </summary>
            /// <param name="windowHandle">Handle to the window receiving notifications.</param>
            public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
            {
                DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
                {
                    DeviceType = DbtDevtypDeviceinterface,
                    Reserved = 0,
                    ClassGuid = GuidDevinterfaceUSBDevice,
                    Name = 0
                };

                dbi.Size = Marshal.SizeOf(dbi);
                IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
                Marshal.StructureToPtr(dbi, buffer, true);

                notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
            }

            /// <summary>
            /// Unregisters the window for USB device notifications
            /// </summary>
            public static void UnregisterUsbDeviceNotification()
            {
                UnregisterDeviceNotification(notificationHandle);
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

            [DllImport("user32.dll")]
            private static extern bool UnregisterDeviceNotification(IntPtr handle);

            [StructLayout(LayoutKind.Sequential)]
            private struct DevBroadcastDeviceinterface
            {
                internal int Size;
                internal int DeviceType;
                internal int Reserved;
                internal Guid ClassGuid;
                internal short Name;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Settings formSetting = new Settings();
            formSetting.Left = Right;
            formSetting.ShowDialog();
            formSetting.Dispose();
            formSetting = null;
        }

        private void toolStripPlatformCombo_Click(object sender, EventArgs e)
        {


        }

        private void SetSubstituteDrives()
        {
            SetSubstituteDrives(selectedVersion);
        }

        private void SetSubstituteDrives(string strVersion)
        {
            if ((strVersion != null) && (strVersion.Length > 0))
            {
                version v = currentDrivePlatform.FindVersion(strVersion);

                if (v != null)
                {
                    string setdrivespath = null;

                    setdrivespath = v.path + @"\set_drive.bat";
                    currentDrivePlatform.QuickSetToolPath = setdrivespath;
                    Process.Start(setdrivespath);

                    this.Text = "RAD Platform Drives [" + selectedVersion + "]";
                }

            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetSubstituteDrives();

        }

        private void toolStripButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectedVersion = toolStripPlatformCombo.Text;
            currentDrivePlatform.Version = selectedVersion;
        }

        private void toolStripPlatformCombo_TextChanged(object sender, EventArgs e)
        {
            selectedVersion = toolStripPlatformCombo.Text;
            currentDrivePlatform.Version = selectedVersion;
        }

        private void AdjustControls()
        {

        }
        private void popupdnbtn_Click(object sender, EventArgs e)
        {
            int width = 0;

            width = Size.Width;
            // 710 
            if (bCollapseExpand)
            {
                Size = new Size(width, 1);
                bCollapseExpand = false;
                treeView1.Location = new Point(0, toolStrip1.Location.Y + toolStrip1.Height);
                treeView1.Size = new Size(treeView1.Size.Width, 1);
            }
            else
            {
                Size = new Size(width, toggleHeight);
                bCollapseExpand = true;
                treeView1.Location = new Point(0, toolStrip1.Location.Y + toolStrip1.Height);
                treeView1.Size = new Size(treeView1.Size.Width, toggleHeight - (toolStrip1.Location.Y + toolStrip1.Height + 40));
            }
            treeView1.Update();
            popupdnbtn.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            popupdnbtn.Update();

        }

        private void FormDrives_ClientSizeChanged(object sender, EventArgs e)
        {
            if ((AllInitialized == true))
            {
                formHeight = Height;

                treeView1.Location = new Point(0, toolStrip1.Location.Y + toolStrip1.Height);
                treeView1.Size = new Size(Size.Width, formHeight - (toolStrip1.Location.Y + toolStrip1.Height + 40));
                treeView1.Update();
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if ((currentDrivePlatform.Version != null) && (currentDrivePlatform.Version.Length > 0))
            {
                version v = currentDrivePlatform.FindVersion(currentDrivePlatform.Version);

                if (v != null)
                {
                    string buildtool = v.path + @"\Devtree\bldtools\BuildMS.exe";

                    string bldtoopen = currentDrivePlatform.BldDirectortyPath + @"\" + currentDrivePlatform.BldFileName;

                    Process.Start(buildtool, bldtoopen);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if ((currentDrivePlatform.Version != null) && (currentDrivePlatform.Version.Length > 0))
            {
                version v = currentDrivePlatform.FindVersion(currentDrivePlatform.Version);

                if (v != null)
                {
                    string buildPath = null;

                    buildPath = v.path;
                    currentDrivePlatform.pBar = toolStripProgressBar; // progressBar1;
                    currentDrivePlatform.DeleteFilesByFilter(buildPath, "*.pch;*.obj");
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtontoolStripButtonRADDeliveryTool_Click(object sender, EventArgs e)
        {

            if ((currentDrivePlatform.Rad2DDeliveryTool != null) && (currentDrivePlatform.Rad2DDeliveryTool.Length > 0))
            {
                radDeliveryTool = Process.Start(currentDrivePlatform.Rad2DDeliveryTool);

                toolStripProgressBar.Maximum = 101;
                toolStripProgressBar.MarqueeAnimationSpeed = 20;
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                do
                {
                    if (toolStripProgressBar.Value > 100)
                    {
                        toolStripProgressBar.Value = 0;
                    }

                    toolStripProgressBar.Value++;
                    System.Threading.Thread.Sleep(20);
                }
                while (false == radDeliveryTool.HasExited);
                toolStripProgressBar.Visible = false;
                toolStripProgressBar.Style = ProgressBarStyle.Continuous;

                System.Threading.Thread.Sleep(100);

                refreshBuildPlatform();
            }

        }
        private void toolStripButtonS3DDeliveryTool_Click(object sender, EventArgs e)
        {
            if ((currentDrivePlatform.S3DDeliveryTool != null) && (currentDrivePlatform.S3DDeliveryTool.Length > 0))
            {
                s3dDeliveryTool = Process.Start(currentDrivePlatform.S3DDeliveryTool);
                toolStripProgressBar.Maximum = 101;
                // progressBar1.ForeColor = Color.Crimson;
                toolStripProgressBar.MarqueeAnimationSpeed = 20;
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                do
                {
                    if (toolStripProgressBar.Value > 100)
                    {
                        toolStripProgressBar.Value = 0;
                    }

                    toolStripProgressBar.Value++;
                    System.Threading.Thread.Sleep(20);
                }
                while (false == s3dDeliveryTool.HasExited);
                toolStripProgressBar.Visible = false;
                toolStripProgressBar.Style = ProgressBarStyle.Continuous;

                System.Threading.Thread.Sleep(100);

                refreshBuildPlatform();
            }
        }

        private void toolStripButtonTFSAuditTool_Click(object sender, EventArgs e)
        {
            if ((currentDrivePlatform.AuditTool != null) && (currentDrivePlatform.AuditTool.Length > 0))
            {
                Process.Start(currentDrivePlatform.AuditTool);
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string strDrive = null;
            TreeNode pNode = null;
            int posIndex = -1;

            if (e.Button == MouseButtons.Right)
            {
                pNode = e.Node.Parent;

                if (pNode != null)
                {
                    if ((pNode.Level == 1))
                    {
                        strDrive = pNode.Text;

                        posIndex = strDrive.LastIndexOf(@"\");

                        if (posIndex != -1)
                        {
                            strDrive = currentDrivePlatform.Left(strDrive, posIndex + 1);
                        }

                        //MessageBox.Show(strDrive + " [ " + pNode.Text + " ]");
                    }
                    else if (e.Node.Level == 1)
                    {
                        strDrive = e.Node.Text;
                        posIndex = strDrive.LastIndexOf(@"\");

                        if (posIndex != -1)
                        {
                            strDrive = currentDrivePlatform.Left(strDrive, posIndex + 1);
                        }

                        //MessageBox.Show(strDrive + " [ " + pNode.Text + " ]");
                    }
                    else
                    {
                        strDrive = null;
                    }

                    if (strDrive != null)
                    {
                        Process.Start("explorer.exe", strDrive);
                    }
                }
            }

        }

        private void refreshBuildPlatform()
        {
            platform = new currentDrivePlatform();  // Reinitialize.
            currentDrivePlatform.LoadPlatFormTableByEnumerateFiles();
            toolStripPlatformCombo.Items.Clear();
            currentDrivePlatform.LoadComboBox(toolStripPlatformCombo);
            toolStripPlatformCombo.Text = currentDrivePlatform.Version;

        }

        private void toolStripButtonDeleteBuild_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            RemoveBuild formRemoveBlds = new RemoveBuild();
            formRemoveBlds.Top = this.Bottom;
            formRemoveBlds.pBar = toolStripProgressBar;
            formRemoveBlds.pLabel = toolStripStatusLabel1;
            dr = formRemoveBlds.ShowDialog();

            if (dr == DialogResult.OK)
            {
                refreshBuildPlatform();
            }
            formRemoveBlds.Dispose();
            formRemoveBlds = null;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            refreshBuildPlatform();
        }

        private void toolStripSetDriveScript_Click(object sender, EventArgs e)
        {
            string dirPath = currentDrivePlatform.BldDirectortyPath;
            //string buildPath = currentDrivePlatform.BuildsPath;
            string filePath = currentDrivePlatform.BldFileName;
            version v = currentDrivePlatform.FindVersion(toolStripPlatformCombo.Text);
            string SetDrivesFilePath = v.path + @"/set_drive.bat";
            int posIndex = -1;

            if (SetDrivesFilePath.Length != 0)
            {
                StreamWriter file = new StreamWriter(SetDrivesFilePath);

                file.WriteLine("REM Set Drive.bat file for " + v.versionName);
                file.WriteLine();

                if (currentDrivePlatform.GenerateSubstDelete)
                {

                    file.WriteLine(@"subst L: /d");

                    file.WriteLine(@"subst M: /d");

                    file.WriteLine(@"subst R: /d");

                    file.WriteLine(@"subst T: /d");

                    file.WriteLine(@"subst X: /d");

                    file.WriteLine(@"subst S: /d");

                    file.WriteLine(@"subst K: /d");

                    file.WriteLine(@"subst Y: /d");

                    file.WriteLine(@"subst N: /d");

                    file.WriteLine(@"subst Z: /d");

                }
                else
                {

                    foreach (string d in Directory.GetDirectories(v.path))
                    {
                        dirPath = d.ToUpper();
                        posIndex = dirPath.LastIndexOf(@"DEVTREE");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst L: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"MROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst M: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"RROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst R: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"TROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst T: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"XROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst X: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"SROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst S: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"KROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst K: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"YROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst Y: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"NROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst N: /d");
                            continue;
                        }

                        posIndex = dirPath.LastIndexOf(@"ZROOT");
                        if (posIndex != -1)
                        {
                            file.WriteLine(@"subst Z: /d");
                            continue;
                        }

                    }
                }

                file.WriteLine(@"subst U: /d");

                file.WriteLine();

                foreach (string d in Directory.GetDirectories(v.path))
                {
                    dirPath = d.ToUpper();
                    posIndex = dirPath.LastIndexOf(@"DEVTREE");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst L: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"MROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst M: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"RROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst R: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"TROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst T: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"XROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst X: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"SROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst S: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"KROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst K: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"YROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst Y: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"NROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst N: " + "\"" + d + "\"");
                        continue;
                    }

                    posIndex = dirPath.LastIndexOf(@"ZROOT");
                    if (posIndex != -1)
                    {
                        file.WriteLine(@"subst Z: " + "\"" + d + "\"");
                        continue;
                    }

                }
                file.WriteLine(@"subst U: " + "\"" + v.path + "\"");
                file.Close();
                file.Dispose();
                file = null;
            } 

            return;
        }

        private void toolStripPatcher_Click(object sender, EventArgs e)
        {
            if ((currentDrivePlatform.PatcherTool != null) && (currentDrivePlatform.PatcherTool.Length > 0))
            {
                Process.Start(currentDrivePlatform.PatcherTool);
            }

        }

        private void toolStripButtonRegEngine_Click(object sender, EventArgs e)
        {
            if ((currentDrivePlatform.S3DRegistryTool != null) && (currentDrivePlatform.S3DRegistryTool.Length > 0))
            {
                Process.Start(currentDrivePlatform.S3DRegistryTool);
            }

        }
    }
}
