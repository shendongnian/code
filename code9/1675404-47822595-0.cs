    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
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
                string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True";
                string sql = "SELECT * FROM Authors";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Authors_table");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Authors_table";
            }
        }
    }
