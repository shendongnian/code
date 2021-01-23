    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
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
                string connetionString = null;
                SqlConnection connection ;
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = null;
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);
                sql = "insert into product (Product_id,Product_name,Product_price) values(6,'Product6',600)";
                try
                {
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show ("Row inserted !! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
