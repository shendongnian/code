    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    
    
    namespace DataGridView_45378237
    {
        
    
        public partial class Form1 : Form
        {
    
            DataGridView my_datagridview = new DataGridView();
            DataTable my_datatable = new DataTable();
            BindingList<MyDatagridviewEntry> myDataGridviewSource = new BindingList<MyDatagridviewEntry>();
    
    
            public Form1()
            {
                InitializeComponent();
                InitializeDataGridView();
            }
    
            private void InitializeDataGridView()
            {
                my_datagridview.Location = new Point(this.Location.X + 15, this.Location.Y + 15);
                my_datagridview.AutoGenerateColumns = true;
                my_datagridview.DataSource = myDataGridviewSource;
                this.Controls.Add(my_datagridview);
            }
    
            private void btnRead_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Text Files";
    
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
    
                openFileDialog1.DefaultExt = "m3u";
                openFileDialog1.Filter = "All files (*.*)|*.*|m3u files (*.m3u)|*.m3u";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
    
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;
    
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = openFileDialog1.FileName;
                    FillDataGridFromFile(sFileName);
                }
            }
    
            private void FillDataGridFromFile(string incomingFilePath)
            {
                //empty the list
                myDataGridviewSource.Clear();
    
                //fill the list
                using (StreamReader sr = new StreamReader(incomingFilePath))
                {
                    string currentLine = string.Empty;
    
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        string[] splittedString = currentLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string f1 = splittedString.Length > 0 ? splittedString[0] : string.Empty;
                        string f2 = splittedString.Length > 1 ? splittedString[1] : string.Empty;
                        string f3 = splittedString.Length > 2 ? splittedString[2] : string.Empty;
                        string f4 = splittedString.Length > 3 ? splittedString[3] : string.Empty;
                        myDataGridviewSource.Add(new MyDatagridviewEntry { Col1 = f1, Col2 = f2, Col3 = f3, Col4 = f4 });
                    }
                }
            }
    
    
        }
    
        public class MyDatagridviewEntry
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
            public string Col3 { get; set; }
            public string Col4 { get; set; }
        }
    }
