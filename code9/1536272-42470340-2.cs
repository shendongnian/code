    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        DataTable PretendImADataBase;
        public Form1()
        {
            InitializeComponent();
            PretendImADataBase = CreateTestData();
            //this assigns the row enter event to this function.  Each time the row changes,
            //the function is called.  Inside this function, you load your "big data" columns.
            //That way, you only load 2 or 3 columns for all rows, and each time the row changes,
            //you go back out and load all of the details for only that 1 row.
            //Pretty basic way to load data..
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            //initial loading, only 1 or 2 columns of large dataset, to keep loading time fast.
            //primary key, and enough info to identify the full record.            
            dataGridView1.DataSource = CreateDataSource1();
        }        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) 
        {
            //This is where you would make your database call to load big data.
            var x = sender as DataGridView;
            if (x.DataSource == null) return;
            var id = x[0, e.RowIndex].Value;
            DataRow oRow = (from DataRow row in PretendImADataBase.Rows where (int)row["FK"] == (int)id select row).FirstOrDefault();
            if (!(oRow == null))
            {
                textBox1.Text = oRow[3].ToString();
                textBox2.Text = oRow[4].ToString();
            }
        }
        private DataTable CreateTestData()
        {
            DataTable oDt = new DataTable();
            DataColumn oCol = new DataColumn("ID", typeof(int));
            oDt.Columns.Add(oCol);
            oCol = new DataColumn("FK", typeof(int));
            oDt.Columns.Add(oCol);
            oCol = new DataColumn("Data1", typeof(string));
            oDt.Columns.Add(oCol);
            oCol = new DataColumn("Data2", typeof(string));
            oDt.Columns.Add(oCol);
            DataRow oRow = oDt.NewRow();
            oRow["ID"] = 1;
            oRow["FK"] = 1;
            oRow["Data1"] = "Test Data 1";
            oRow["Data2"] = "Test Data 2";
            oDt.Rows.Add(oRow);
            oRow = oDt.NewRow();
            oRow["ID"] = 2;
            oRow["FK"] = 2;
            oRow["Data1"] = "Test Data 3";
            oRow["Data2"] = "Test Data 4";
            oDt.Rows.Add(oRow);
            return oDt;
        }
        private DataTable CreateDataSource1()
        {
            DataTable oDt = new DataTable();
            DataColumn oCol = new DataColumn("ID",typeof(int));
            oDt.Columns.Add(oCol);
            oCol = new DataColumn("Display", typeof(string));
            oDt.Columns.Add(oCol);
            DataRow oRow = oDt.NewRow();
            oRow["ID"] = 1;
            oRow["Display"] = "Test 1";
            oDt.Rows.Add(oRow);
            oRow = oDt.NewRow();
            oRow["ID"] = 2;
            oRow["Display"] = "Test 2";
            oDt.Rows.Add(oRow);
            return oDt;
        }
    }
    }
