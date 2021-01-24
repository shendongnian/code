    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.OleDb;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            const string FILENAME = @"c:\temp\test.csv";
            private void button1_Click(object sender, EventArgs e)
            {
                CSVReader csvReader = new CSVReader();
                DataSet ds = csvReader.ReadCSVFile(FILENAME, true);
                dataGridView1.DataSource = ds.Tables["Table1"];
            }
        }
        public class CSVReader
        {
            public DataSet ReadCSVFile(string fullPath, bool headerRow)
            {
                string path = fullPath.Substring(0, fullPath.LastIndexOf("\\") + 1);
                string filename = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                DataSet ds = new DataSet();
                try
                {
                    if (File.Exists(fullPath))
                    {
                        string ConStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}" + ";Extended Properties=\"Text;HDR={1};FMT=Delimited\\\"", path, headerRow ? "Yes" : "No");
                        string SQL = string.Format("SELECT * FROM {0}", filename);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, ConStr);
                        adapter.Fill(ds, "TextFile");
                        ds.Tables[0].TableName = "Table1";
                    }
                    foreach (DataColumn col in ds.Tables["Table1"].Columns)
                    {
                        col.ColumnName = col.ColumnName.Replace(" ", "_");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return ds;
            }
        }
    }
