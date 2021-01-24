    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.OleDb;
    using System.Data;
    namespace EXEL_DB
    {
    public partial class Form1 : Form
    {
        OleDbConnection coon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=""C:\A.xls""; Extended properties=""Excel 8.0;HDR=Yes;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0""");
        OleDbCommand com;
        DataTable dt = new DataTable();
        OleDbDataAdapter da;
        public Form1()
        {
            coon.Open();
            fillgrilll("");
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = new System.Data.DataView(dt);
           
            dv.RowFilter = "group by [langue com] order by [langue com]";
            dataGridView1.DataSource = dv;
        }
        void fillgrilll(string re)
        {
            try
            {
                dt.Clear();
                   // My sheet i name it A but you have to write [A$]
                da = new OleDbDataAdapter("select * from [A$] where datepart(month,[Shipment Date]) = datepart(month,'06/04/2016')", coon);
                da.Fill(dt);
                //dataGridView1.DataSource = dt;
            }
            catch {
                MessageBox.Show("Errr");
            }
        }
    }
    }
` 
