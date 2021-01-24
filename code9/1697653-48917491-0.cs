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
                SqlCommand command ;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataView dv ;
                string sql = null;
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                sql = "Select * from product";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    adapter.SelectCommand = command;
                    adapter.Fill(ds, "Update");
                    adapter.Dispose();
                    command.Dispose();
                    connection.Close();
    
                    dv = new DataView(ds.Tables[0], "", "Product_Name", DataViewRowState.CurrentRows);
                    int index = dv.Find("PRODUCT5");
    
                    if (index == -1)
                    {
                        MessageBox.Show ("Product not found");
                    }
                    else
                    {
                        dv[index]["Product_Name"] = "Product11";
                        MessageBox.Show("Product Updated !");
                    }
    
                    dataGridView1.DataSource = dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
 
