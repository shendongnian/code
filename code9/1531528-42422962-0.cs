    using System;
    using System.Windows.Forms;
    using System.Data;
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
                string connetionString = null;
                SqlConnection sqlCnn ;
                SqlCommand sqlCmd ;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                int i = 0;
                string sql = null;
    
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                sql = "Select * from product";
    
                sqlCnn = new SqlConnection(connetionString);
                try
                {
                    sqlCnn.Open();
                    sqlCmd = new SqlCommand(sql, sqlCnn);
                    adapter.SelectCommand = sqlCmd;
                    adapter.Fill(ds);
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                    }
                    adapter.Dispose();
                    sqlCmd.Dispose();
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
        }
    }
