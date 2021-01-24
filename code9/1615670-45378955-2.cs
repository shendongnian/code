    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    
    using System.Text.RegularExpressions;
    
    namespace DataGridView_45378237
    {
        
    
        public partial class Form1 : Form
        {
    
            DataGridView my_datagridview = new DataGridView();//the DataGridView which will be put on the form
            BindingList<MyDatagridviewEntry> myDataGridviewSource = new BindingList<MyDatagridviewEntry>();//the BindingList from which the DataGridView will pull its data
    
    
            public Form1()
            {
                InitializeComponent();
                InitializeDataGridView();//set the initial settings of the DataGridView
            }
    
            private void InitializeDataGridView()
            {
                my_datagridview.Location = new Point(this.Location.X + 15, this.Location.Y + 15);//define where to place it in the form(you could obviously just place one directly where you want using the wysiwyg)
                this.Controls.Add(my_datagridview);
    
                my_datagridview.AutoSize = true;
                my_datagridview.AutoGenerateColumns = true;
                my_datagridview.DataSource = myDataGridviewSource;//link the DataGridView with the BindingSource
                
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
                    FillDataGridFromFile(sFileName);//send the file to get parsed
                }
            }
    
            private void FillDataGridFromFile(string incomingFilePath)
            {
                //empty the list
                myDataGridviewSource.Clear();//you may or may not want this... I don't know your full requirements...
    
                //fill the list
                using (StreamReader sr = new StreamReader(incomingFilePath))
                {
                    string currentLine = string.Empty;
    
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        /*This is not how I would write the production code,
                         * but for the sake of this example, this format works well
                         so that you know what is being done and why.*/
                        string[] splittedString = currentLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string f1 = splittedString.Length > 0 ? splittedString[0] : string.Empty;//if splittedString has more than 0 entries, the use entry[0], else use string.empty
                        string f2 = splittedString.Length > 1 ? splittedString[1] : string.Empty;//if splittedString has more than 1 entries, the use entry[1], else use string.empty
                        string f3 = GetTVGNameFromString(splittedString[0]);//Extract the text from within the string
                        string f4 = splittedString.Length > 3 ? splittedString[3] : string.Empty;//if splittedString has more than 3 entries, the use entry[3], else use string.empty
                        /**/
    
                        //add the entry to the BindingSource
                        myDataGridviewSource.Add(new MyDatagridviewEntry { Col1 = f1, Col2 = f2, Col3 = f3, Col4 = f4 });
                    }
                }
            }
    
    
    
            private string GetTVGNameFromString(string incomingString)
            {
                string retval = string.Empty;
                Regex rgx = new Regex("tvg-name=\"([^\"]*)\"");//use a grouping regex to find what you are looking for
                if (rgx.IsMatch(incomingString))
                {
                    return rgx.Matches(incomingString)[0].Groups[1].Value;
                }
                return retval;
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
