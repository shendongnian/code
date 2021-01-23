    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    
    namespace LOC_Counter
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            void getFileList(string directory)
            {
                string[] dirs = Directory.GetDirectories(directory);
    
                foreach (string dir in dirs)
                {
                    getFileList(dir);
                }
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
    
                    StreamReader sr = File.OpenText(file);
    
                    int nLineCount = 0;
                    string str = string.Empty;
                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        if (str != null && str.Length > 0 && (str.Length > 2 && str.Substring(0, 2) != "//") && (str.Length > 3 && str.Substring(0, 4) != "<!--"))
                        nLineCount++;
                    }
                    lstbxResult.Items.Add(file + "              Line count - " + nLineCount);
    
                }
    
    
    
            }
    
            private void btnBrowse_Click(object sender, EventArgs e)
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
    
                if (FBD.ShowDialog() == DialogResult.OK)
                {
    
                    lstbxResult.Items.Clear();
                    getFileList(FBD.SelectedPath);
    
                }
            }
    
            public static void ExportToExcel(ListBox lst, string excel_file)
            {
                int cols;
                //open file
                StreamWriter wr = new StreamWriter(excel_file);
    
                //write rows to excel file
                for (int i = 0; i < (lst.Items.Count - 1); i++)
                {
                    wr.Write(lst.Items[i].ToString() + "\t");
    
                    wr.WriteLine();
                }
    
                //close file
                wr.Close();
            }
    
            private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
