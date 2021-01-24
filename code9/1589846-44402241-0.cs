    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                folderBrowserDialog1.SelectedPath = @"c:\temp";
            }
            private void buttonBrowseForFolder_Click(object sender, EventArgs e)
            {
                folderBrowserDialog1.ShowDialog();
                textBoxFolderName.Text = folderBrowserDialog1.SelectedPath;
            }
            private void buttonMakeTree_Click(object sender, EventArgs e)
            {
                if (Directory.Exists(textBoxFolderName.Text))
                {
                    MyDirectory root = MyDirectory.root;
                    MakeTreeRecursive(textBoxFolderName.Text, root);
                    textBoxTotalNumberOfFiles.Text = root.totalNumberOfFiles.ToString();
                    textBoxTotalSize.Text = root.totalSize.ToString();
                }
            }
            private void MakeTreeRecursive(string folder, MyDirectory myDirectory)
            {
                myDirectory.name = folder.Substring(folder.LastIndexOf("\\") + 1);
                DirectoryInfo dInfo = new DirectoryInfo(folder);
                myDirectory.numberOfFiles = 0;
                myDirectory.size = 0.0f;
                foreach (FileInfo fInfo in dInfo.GetFiles())
                {
                    try
                    {
                        float fSize = fInfo.Length;
                        myDirectory.size += fSize;
                        myDirectory.numberOfFiles += 1;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error : CAnnot Access File '{0}'", fInfo.Name);
                    }
                }
                myDirectory.totalSize = myDirectory.size;
                myDirectory.totalNumberOfFiles = myDirectory.numberOfFiles;
                foreach (string subFolder in Directory.GetDirectories(folder))
                {
                    if (myDirectory.children == null) myDirectory.children = new List<MyDirectory>();
                    MyDirectory childDirectory = new MyDirectory();
                    myDirectory.children.Add(childDirectory);
                    MakeTreeRecursive(subFolder, childDirectory);
                    myDirectory.totalSize += childDirectory.totalSize;
                    myDirectory.totalNumberOfFiles += childDirectory.totalNumberOfFiles;
                }
            }
        }
        public class MyDirectory
        {
            public static MyDirectory root = new MyDirectory();
            public List<MyDirectory> children { get; set; }
            public string name { get; set; }
            public long totalNumberOfFiles = 0;
            public int numberOfFiles = 0;
            public float size = 0.0f;
            public float totalSize = 0.0f;
        }
    }
