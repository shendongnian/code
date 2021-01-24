    using System.Data.SqlClient;
    
    public class Form1
    {
        DataSet ds = new DataSet;
        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=name_of_your_sql_server; Integrated Security=true; Initial Catalog=name_of_your_database");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Categories", con);
            da.Fill(ds, "Cat");
            DataGridView1.DataSource = ds.Tables("Cat");
        }
    
        private void TextBox1_TextChanged(System.Object sender, System.EventArgs e)
        {
            ds.Tables("Cat").DefaultView.RowFilter = "[CategoryName] LIKE '*" + TextBox1.Text + "*'";
        }
    }
