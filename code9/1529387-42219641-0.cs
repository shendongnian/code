       private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtCPData = new DataTable();
            string sqlconstr = "Data Source=dbhost;Initial Catalog=dbname;Persist Security Info=True;User ID=username;Password=password";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = sqlconstr;
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from Table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtCPData);
            con.Close();
        }
