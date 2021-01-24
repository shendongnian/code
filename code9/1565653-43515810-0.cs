    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace divideSquare
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void btn_Backup_Click(object sender, EventArgs e)
            {
                List<DirectoryInfo> SourceDir = this.lbox_Sources.Items.Cast<DirectoryInfo>().ToList();
                List<DirectoryInfo> TargetDir = this.lbox_Targets.Items.Cast<DirectoryInfo>().ToList();
                for(int i = 0; i < SourceDir.Count(); i++)
                {
                    DirectoryInfo sourcedir = SourceDir[i];
                    DirectoryInfo targetdir = TargetDir[i];
                    RecursiveZip(sourcedir, targetdir);
                }
            }
            private void RecursiveZip(DirectoryInfo sourcedir, DirectoryInfo targetdir)
            {
                    string dateString = DateTime.Now.ToString("MM-dd-yyyy_H.mm.ss");
                    if (this.checkbox_zipfiles.Checked == true)
                    {
                        System.IO.Compression.ZipFile.CreateFromDirectory(sourcedir, targetdir.FullName + @"\BACKUP_" + sourcedir.Name + @"_" + dateString + @".zip");
                        LogBackup();
                    }
                    else
                    {
                        foreach (var file in sourcedir.GetFiles()
                            .Where(f => !extensionsToSkip.Contains(f.Extension) && !filesToSkip.Contains(f.FullName)).ToList())
                        {
                            file.CopyTo(targetdir.FullName + @"\" + file.Name, true);
                            LogBackup();
                        }
                        foreach(DirectoryInfo folder in sourcedir.GetDirectories())
                        {
                            RecursiveZip(folder, new DirectoryInfo(targetdir.FullName + "\\" + folder.Name));
                        }
                    }
            }
    }
