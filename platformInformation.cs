using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.Contracts;
using System.Drawing;

namespace CurrentDrives
{
    public class version
    {
        private string versionString;
        private string vpath;

        /// <summary>
        /// Constructor of the version object.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="path"></param>
        public version(string version, string path)
        {
            versionString = version;
            vpath = path;
        }

        /// <summary>
        /// Return the version.
        /// </summary>
        public string versionName
        {
            get { return versionString; }
        }

        /// <summary>
        /// Returns or sets the file path for the version.
        /// </summary>
        public string path
        {
            get { return vpath; }
            set {
                Contract.Requires(value.Length > 0);
                vpath = value;
            }
        }

    }
    public class versionCollection : IEnumerable
    {
        private ArrayList vrList = new ArrayList();

        /// <summary>
        /// Return the version object at given position.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public version GetVersion(int pos)
        {
            return (version)vrList[pos];
        }

        /// <summary>
        /// Return the version object of a given version.
        /// </summary>
        /// <param name="versionKey"></param>
        /// <returns></returns>
        public version GetVersion(string versionKey)
        {
            version returnVersion = null;

            foreach (version vr in vrList)
            {
                if (vr.versionName == versionKey)
                {
                    returnVersion = vr;
                    break;
                }
            }


            return returnVersion;
        }

        /// <summary>
        /// Add a version to the collection.
        /// </summary>
        /// <param name="vr"></param>
        public void AddVersion(version vr)
        {
            vrList.Add(vr);
        }

        /// <summary>
        /// Return the number of items in the collection.
        /// </summary>
        public int Count
        {
            get { return vrList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return vrList.GetEnumerator();
        }

        /// <summary>
        /// Remove the object from collection.
        /// </summary>
        /// <param name="obj"></param>
        public void Remove(object obj)
        {
            vrList.Remove(obj);
        }

        /// <summary>
        /// Remove a version at index location.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            vrList.RemoveAt(index);
        }

        /// <summary>
        /// Clear the Version Collection.
        /// </summary>
        public void Clear()
        {
            vrList.Clear();
        }
    }


    public class StringCollection : IEnumerable
    {
        private ArrayList vrList = new ArrayList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public string GetString(int pos)
        {
            return (string)vrList[pos];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str)
        {
            vrList.Add(str);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return vrList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return vrList.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Remove(object obj)
        {
            vrList.Remove(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            vrList.RemoveAt(index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            vrList.Clear();
        }

    }

    public static class buildFunctions
    {
        private static string fileFilterForDeletion = "*.obj";

     //   private static ProgressBar progressBar = null;
        private static ToolStripProgressBar progressBar = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDir"></param>
        /// <param name="strFilter"></param>
        /// <param name="strList"></param>
        private static void DirSearch(string sDir, string strFilter, StringCollection strList)
        {
            //  StringCollection strList = new StringCollection();
            try
            {
                if (strList == null)
                {
                    strList = new StringCollection();
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, strFilter))
                    {
                        strList.Add(f);
                    }
                    DirSearch(d, strFilter, strList);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return;
        }

        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;

            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        //public static ProgressBar pBar
        public static ToolStripProgressBar pBar
        {
            get { return progressBar; }
            set { progressBar = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        private static StringCollection GetFilesCollection(string baseDirectory, string strFilter)
        {
            StringCollection strExt = new StringCollection();
            StringCollection strReturn = new StringCollection();
            StringCollection strList = new StringCollection();
            string strSubFilter;
            string strArgFilter = strFilter;

           // Contract.Assume(false == string.IsNullOrEmpty(baseDirectory), "base directory must be defined.");

            if (strFilter.Length == 0)
            {
                strFilter = fileFilterForDeletion;
            }
            else
            {

                int posIndex = strFilter.LastIndexOf(@";");

                do
                {
                    if (posIndex == -1)
                    {
                        strSubFilter = strFilter;

                        strFilter = "";

                    }
                    else
                    {
                        strSubFilter = strFilter.Substring(posIndex + 1);
                        strFilter = Left(strFilter, posIndex);
                        posIndex = strFilter.LastIndexOf(@";");
                    }

                    strExt.Add(strSubFilter);



                } while (strFilter.Length > 0);

            }

            if (baseDirectory.Length > 0)
            {
                foreach (string sfilter in strExt)
                {
                    DirSearch(baseDirectory, sfilter, strList);

                    if (strList != null)
                    {
                        foreach (string file in strList)
                        {

                            strReturn.Add(file);

                        }

                        strList.Clear();
                        strList = null;
                    }
                }

            }
            return strReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public static int DeleteFilesByFilter(string baseDirectory, string strFilter)
        {
            int count = 0;
            int currentCount = 0;
            StringCollection strExt = null;

           // Contract.Assume(false == string.IsNullOrEmpty(baseDirectory), "base directory must be defined.");
            
            strExt = GetFilesCollection(baseDirectory, strFilter);

            if (strExt != null)
            {
                count = strExt.Count;
                if (progressBar != null)
                {

                    progressBar.Maximum = strExt.Count;
                    progressBar.Value = 0;
                    progressBar.Visible = true;
                }
                currentCount = 0;
                foreach (string file in strExt)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (DirectoryNotFoundException e)
                    {

                        MessageBox.Show("Could not delete " + file + " because could not find it. Exception Message : " + e.Message);
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show("Could not delete " + file + " because  : " + e.Message);
                    }

                    currentCount++;
                    if (progressBar != null)
                    {
                        progressBar.Value = currentCount;
                    }

                    System.Threading.Thread.Sleep(20);

                    //MessageBox.Show("File to delete - " + file);
                }
                strExt.Clear();
                strExt = null;
            }

            if (progressBar != null)
            {
                progressBar.Visible = false;
            }

            return count;
        }
    }

    public static class platformInformation
    {

        public const string SUBST_DEF_BAT = "set_drive.bat";
        public const string xmlFile = "C:\\temp\\currrentDrives.xml";
        private static string platformBase = "";
        private static Boolean rememberVersion = false;
        private static Boolean generateSubstDelete = false;
        private static string rememberedVersion = "";
        private static versionCollection vtable = new versionCollection();

        private static string bldFileToOpen = "BuildAll.bld";
        private static string bldFilePath = @"L:\bldTools";

        private static string radDeliveryTool = @"\\ppm2dbuilds\ZipTools\RADDeliverZips.exe";
        private static string s3dDeliveryTool = @"\\ppm3dbuilds\ziptools\SP3DDeliverZips.exe";
        private static string s3dRegistryTool = @"X:\Bldtools\Tools\RegisterApps.exe";
        private static string patcher = @"L:\bldtools\PatcherV14.exe";

        private static string auditTool = @"\\ppm3dbuilds\ziptools\TFSAudit15.exe";

        private static string elapsedTime = "";
        private static string quickSetToolPath = "";

        public static string QuickSetToolPath
        {
            get { return quickSetToolPath; }
            set { quickSetToolPath = value; }
            
        }

        /// <summary>
        /// Return Left number of characters of given string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ReadPlatFormInformation()
        {
            string strValue;
            platformBase = @"D:\RADPLATFORMS";
            if (File.Exists(xmlFile))
            {
                XmlTextReader textReader = new XmlTextReader(xmlFile);
                while (textReader.Read())
                {
                    XmlNodeType nType = textReader.NodeType;

                    if (nType == XmlNodeType.Element)
                    {
                        Boolean bHasAttribute = textReader.HasAttributes;

                        if (bHasAttribute)
                        {
                            platformBase = textReader.GetAttribute("Base");
                            if ((platformBase != null) && (platformBase.Length == 0))
                            {
                                platformBase = @"D:\RADPLATFORMS";
                            }

                            strValue = textReader.GetAttribute("RememberVersion");
                            if ((strValue != null) && (strValue.Length > 0))
                            {
                                if (strValue == "true")
                                {
                                    rememberVersion = true;
                                }
                                else
                                {
                                    rememberVersion = false;
                                }
                            }

                            rememberedVersion = textReader.GetAttribute("Version");
                            if ((rememberedVersion == null) || (rememberedVersion.Length == 0))
                            {
                                rememberedVersion = "";
                            }

                            quickSetToolPath = textReader.GetAttribute("QuickSetTool");
                            if ((quickSetToolPath != null) && (quickSetToolPath.Length > 0))
                            {
              
                                 Process.Start(quickSetToolPath);

                            }

                            bldFileToOpen = textReader.GetAttribute("BLDFile");

                            if ((bldFileToOpen == null) || (bldFileToOpen.Length == 0))
                            {
                                bldFileToOpen = "BuildAll.bld";
                            }

                            bldFilePath = textReader.GetAttribute("BLDFilePath");

                            if ((bldFilePath == null) || (bldFilePath.Length == 0))
                            {
                                bldFilePath = @"L:\bldTools";
                            }

                            radDeliveryTool = textReader.GetAttribute("radDeliveryTool");

                            if ((radDeliveryTool == null) || (radDeliveryTool.Length == 0))
                            {
                                radDeliveryTool = @"\\ppm2dbuilds\ZipTools\RADDeliverZips.exe";
                            }

                            s3dDeliveryTool = textReader.GetAttribute("s3dDeliveryTool");

                            if ((s3dDeliveryTool == null) || (s3dDeliveryTool.Length == 0))
                            {
                                s3dDeliveryTool = @"\\ppm3dbuilds\ziptools\SP3DDeliverZips.exe";
                            }

                            auditTool = textReader.GetAttribute("AuditTool");

                            if ((auditTool == null) || (auditTool.Length == 0))
                            {
                                auditTool = @"\\ppm3dbuilds\ziptools\TFSAudit15.exe";
                            }

                            strValue = textReader.GetAttribute("generateSubstDelete");
                            if ((strValue != null) && (strValue.Length > 0))
                            {
                                if (strValue == "true")
                                {
                                    generateSubstDelete = true;
                                }
                                else
                                {
                                    generateSubstDelete = false;
                                }
                            }

                            s3dRegistryTool = textReader.GetAttribute("s3dRegistryTool");

                            if ((s3dRegistryTool == null) || (s3dRegistryTool.Length == 0))
                            {
                                s3dRegistryTool = @"X:\Bldtools\Tools\RegisterApps.exe"; 
                            }

                        }

                    }

                }

            }
            else
            {
                platformBase = @"D:\RADPLATFORMS";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        private static void CheckFileForVersionAndAddToVersionTable(string filename)
        {
            version v;
            string strVersion;
            string strPath;

            if (filename.Length > 0)
            {
                strPath = filename;
                int posIndex = strPath.LastIndexOf(@"\");

                if (posIndex != -1)
                {
                    strPath = Left(strPath, posIndex);
                }

                strVersion = strPath;
                posIndex = strVersion.LastIndexOf(@"\");

                if (posIndex != -1)
                {
                    strVersion = strVersion.Substring(posIndex + 1);
                }

                v = new version(strVersion, strPath);

                vtable.AddVersion(v);
            }
        }

        public static void LoadPlatFormTableByGetFiles()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var allFiles = Directory.GetFiles(platformBase, SUBST_DEF_BAT, SearchOption.AllDirectories);

            vtable = new versionCollection();
            foreach (string file in allFiles)
            {
                CheckFileForVersionAndAddToVersionTable(file);
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

        }

        /// <summary>
        /// 
        /// </summary>
        public static void LoadPlatFormTableByEnumerateFiles()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var allFiles = Directory.EnumerateFiles(platformBase, SUBST_DEF_BAT, SearchOption.AllDirectories);

            vtable = new versionCollection();
            foreach (string file in allFiles)
            {
                CheckFileForVersionAndAddToVersionTable(file);
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

        }

/// <summary>
/// 
/// </summary>
        public static void WritePlatformInformation()
        {
            XmlTextWriter textWriter = new XmlTextWriter(xmlFile, null);
            String strValue = "";

            textWriter.WriteStartDocument();

            textWriter.WriteStartElement("BuildsInfo");
            textWriter.WriteAttributeString("Base", platformBase);


            if (rememberVersion == true)
            {
                strValue = "true";
            }
            else
            {
                strValue = "false";
            }
            textWriter.WriteAttributeString("QuickSetTool", quickSetToolPath);
            textWriter.WriteAttributeString("RememberVersion", strValue);

            textWriter.WriteAttributeString("Version", rememberedVersion);

            textWriter.WriteAttributeString("BLDFile", bldFileToOpen);

            textWriter.WriteAttributeString("BLDFilePath", bldFilePath);

            textWriter.WriteAttributeString("radDeliveryTool", radDeliveryTool);
            textWriter.WriteAttributeString("s3dDeliveryTool", s3dDeliveryTool);
            textWriter.WriteAttributeString("AuditTool", auditTool);

            if (generateSubstDelete == true)
            {
                strValue = "true";
            }
            else
            {
                strValue = "false";
            }

            textWriter.WriteAttributeString("generateSubstDelete", strValue);
            textWriter.WriteAttributeString("s3dRegistryTool", s3dRegistryTool);

            textWriter.WriteEndElement();

            textWriter.WriteEndDocument();

            textWriter.Close();
            textWriter.Dispose();
            textWriter=null;
        }

        public static string loadVersionTableElapsedTime
        {
            get { return elapsedTime; }
        }

        public static string BuildsPath
        {
            get { return platformBase; }
            set { platformBase = value; }
        }

        public static int VersionTableCount()
        {
            return vtable.Count;
        }

        public static version FindVersion(string strVersion)
        {
            version version = null;

            foreach (version v in vtable)
            {
                if (v.versionName == strVersion)
                {
                    version = v;
                    break;
                }
            }


            return version;
        }

        public static string GetVersionInPath(string strPath)
        {
            string strResult = null;
            foreach (version v in vtable)
            {
                if (strPath.Contains(v.versionName))
                {
                    strResult = v.versionName;
                    break;
                }
            }

            return strResult;
        }

        public static void LoadComboBox(ToolStripComboBox cmbx)
        {

            foreach (version v in vtable)
            {
                cmbx.Items.Add(v.versionName);
            }
        }
        public static void LoadComboBox(CheckedListBox cmbx)
        {

            foreach (version v in vtable)
            {
                if (rememberedVersion != v.versionName)
                {
                    cmbx.Items.Add(v.versionName);
                }
            }
        }

        public static Boolean RestoreVersion
        {
            get { return rememberVersion; }
            set { rememberVersion = value; }
        }

        public static string Version
        {
            get { return rememberedVersion; }
            set { rememberedVersion = value; }
        }

        public static string BldFileName
        {
            get { return bldFileToOpen; }
            set {
                Contract.Requires(value.Length > 0);
                bldFileToOpen = value;
            }
        }

        public static string BldDirectortyPath
        {
            get { return bldFilePath; }
            set {
                Contract.Requires(value.Length > 0);

                bldFilePath = value;
            }
        }

        
        public static string Rad2DDeliveryTool
        {
            get { return radDeliveryTool; }
            set { radDeliveryTool = value; }
        }

        public static string S3DDeliveryTool
        {
            get { return s3dDeliveryTool; }
            set { s3dDeliveryTool = value; }
        }

        public static string AuditTool
        {
            get { return auditTool; }
            set { auditTool = value; }
        }

        public static string PatcherTool
        {
            get { return patcher; }
            set { patcher = value; }
        }

        public static Boolean GenerateSubstDelete
        {
            get { return generateSubstDelete; }
            set { generateSubstDelete = value; }
        }

        public static string S3DRegistryTool
        {
            get { return s3dRegistryTool; }
            set { s3dRegistryTool = value; }
        }


    }

    public class currentDrivePlatform
    {

        public currentDrivePlatform()
        {
            platformInformation.ReadPlatFormInformation();
           // platformInformation.LoadPlatFormTableByGetFiles();

            

        }

        ~currentDrivePlatform()
        {
            platformInformation.WritePlatformInformation();
        }

        public static void LoadPlatFormTableByEnumerateFiles()
        {
            platformInformation.LoadPlatFormTableByEnumerateFiles();
            return;
        }

        public static string BuildsPath
        {
            get { return platformInformation.BuildsPath; }
            set { platformInformation.BuildsPath = value; }
        }

        public static version FindVersion(string strVersion)
        {
            return platformInformation.FindVersion(strVersion);
        }

        public static void LoadComboBox(ToolStripComboBox cmbx)
        {
            platformInformation.LoadComboBox(cmbx);

        }
        public static void LoadComboBox(CheckedListBox cmbx)
        {
            platformInformation.LoadComboBox(cmbx);

        }

        public static string GetVersionInPath(string strPath)
        {
            return platformInformation.GetVersionInPath(strPath);
        }

        public static Boolean RestoreVersion
        {
            get { return platformInformation.RestoreVersion; }
            set { platformInformation.RestoreVersion = value; }
        }

        public static string Version
        {
            get { return platformInformation.Version; }
            set { platformInformation.Version = value; }
        }

 // public static ProgressBar pBar
        public static  ToolStripProgressBar pBar
        {
            get { return buildFunctions.pBar; }
            set { buildFunctions.pBar = value; }
        }

        public static string BldFileName
        {
            get { return platformInformation.BldFileName; }
            set { platformInformation.BldFileName = value; }
        }

        public static string BldDirectortyPath
        {
            get { return platformInformation.BldDirectortyPath; }
            set { platformInformation.BldDirectortyPath = value; }
        }

        public static int DeleteFilesByFilter(string baseDirectory, string strFilter)
        {
            return buildFunctions.DeleteFilesByFilter(baseDirectory, strFilter);
        }

        public static string Left(string value, int maxLength)
        {
            return platformInformation.Left(value, maxLength);
        }


        public static string Rad2DDeliveryTool
        {
            get { return platformInformation.Rad2DDeliveryTool; }
            set { platformInformation.Rad2DDeliveryTool = value; }
        }

        public static string S3DDeliveryTool
        {
            get { return platformInformation.S3DDeliveryTool; }
            set { platformInformation.S3DDeliveryTool = value; }
        }

        public static string S3DRegistryTool
        {
            get { return platformInformation.S3DRegistryTool; }
            set { platformInformation.S3DRegistryTool = value; }
        }

        public static string AuditTool
        {
            get { return platformInformation.AuditTool; }
            set { platformInformation.AuditTool = value; }
        }

        public static string PatcherTool
        {
            get { return platformInformation.PatcherTool; }
            set { platformInformation.PatcherTool = value; }
        }

        public static Boolean GenerateSubstDelete
        {
            get { return platformInformation.GenerateSubstDelete; }
            set { platformInformation.GenerateSubstDelete = value; }
        }

        public static string loadVersionTableElapsedTime
        {
            get { return platformInformation.loadVersionTableElapsedTime; }
        }

        public static void UpdateColorControls(ToolStripItem myControl, Color bkColor, Color frColor)
        {
            myControl.BackColor = bkColor;
            myControl.ForeColor = frColor;
        }

        public static string QuickSetToolPath
        {
            get { return platformInformation.QuickSetToolPath; }
            set { platformInformation.QuickSetToolPath = value; }
        }
        public static void UpdateColorControls(Control myControl, Color bkColor, Color frColor)
        {
            myControl.BackColor = bkColor;
            myControl.ForeColor = frColor;
            foreach (Control subC in myControl.Controls)
            {
                UpdateColorControls(subC, bkColor,frColor);
            }
        }

    }

}
