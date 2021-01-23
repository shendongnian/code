    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                string FileName = @"C:\mydir\testcsv.csv";
                OleDbConnection conn = new OleDbConnection
                       ("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " +
                         Path.GetDirectoryName(FileName) +
                         "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter
                       ("SELECT * FROM " + Path.GetFileName(FileName), conn);
                DataSet ds = new DataSet("Temp");
                adapter.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Table";
            }
        }
    }
