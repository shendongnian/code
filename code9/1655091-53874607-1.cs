    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\data.mdf;Integrated Security=True");
    con.Open();            
                SqlCommand multikill= new SqlCommand("select count(*) from Table where ID='"+TextBox1.Text+"'", con);            
                if (int.Parse(multikill.ExecuteScalar().ToString()) > 1)
     {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Table where ID='"+TextBox1.Text+"'",bag);
                    DataSet ds = new DataSet();
                    da.Fill(ds,"Table");
                    dataGridView2.DataSource = ds.Tables["Table"];
    }
    con.Close();
           
