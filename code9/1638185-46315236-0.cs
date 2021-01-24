    using System;
    using System.Windows;
    using Microsoft.Win32;
    using Spire.Xls;
    using System.IO;
    
    namespace MergeExcel
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }        
          
            private void btnSelectFile_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Multiselect = true;
                openFileDialog1.Title = "Select Files";
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog1.Filter = "Files(*.xls;*.xlsx;*.csv)|*.xls;*.xlsx;*.csv";            
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                //openFileDialog1.CheckFileExists = true;
                //openFileDialog1.CheckPathExists = true;
                            
                if (openFileDialog1.ShowDialog() == true)
                {
                    foreach (string filename in openFileDialog1.FileNames)
                    {
    
                        listBox1.Items.Add(System.IO.Path.GetFullPath(filename));
                    }
                }
            }
    
            private void btnMergeFile_Click(object sender, RoutedEventArgs e)
            {
                Workbook tempbook = new Workbook();
    
                Workbook workbook = new Workbook();
                workbook.Version = ExcelVersion.Version2013;
                workbook.Worksheets.Clear();
    
               
                foreach (string file in listBox1.SelectedItems)
                {
                    string extension = Path.GetExtension(file);
                    if (extension == ".xlsx" | extension == ".xls")
                    {
                        tempbook.LoadFromFile(file);//Load Excel files
                    }
                    else
                    {
                        tempbook.LoadFromFile(file, ",", 1, 1);//Load CSV files                      
                    }
                    foreach (Worksheet sheet in tempbook.Worksheets)
                    {
                        workbook.Worksheets.AddCopy(sheet);//Merge files
                    }
                }
                string newFileName = textBox1.Text.Trim();
                workbook.SaveToFile(newFileName);
            }       
           
        }
    }
 
