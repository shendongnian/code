    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=your .mdb file;";
                string sql = "SELECT * FROM Authors";
                OleDbConnection connection = new OleDbConnection(connetionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Authors_table");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Authors_table";
            }
        }
    }
