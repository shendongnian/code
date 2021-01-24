    using System.ComponentModel;
    using System.Windows.Forms;
    using System.IO;
    
    namespace DatagridView_AddRowsAfterInitialLoad_45922121
    {
        public partial class Form1 : Form
        {
            string filePath = "";
    
            BindingList<dgventry> dgvSourceList = new BindingList<dgventry>();
    
            public Form1()
            {
                InitializeComponent();
                InitializeDGV();
                //put initial values in the grid
                dgvSourceList.Add(new dgventry { field1 = "yeah", field2 = "yeah in f2", field3 = "yeah in F3" });
                //put values from the datafile
                getTexFilePath();
            }
    
            private void InitializeDGV()
            {
                dataGridView1.DataSource = dgvSourceList;
            }
    
            private void getTexFilePath()
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Text Files";
    
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
    
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
    
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;
    
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
    
                    foreach (var line in File.ReadAllLines(filePath))
                    {
                        dgvSourceList.Add(new dgventry { field1 = line, field2 = "", field3 = "" });
                    }
                }
            }
        }
    
        public class dgventry
        {
            public string field1 { get; set; }
            public string field2 { get; set; }
            public string field3 { get; set; }
        }
    
    
    }
