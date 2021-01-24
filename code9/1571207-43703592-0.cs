    private void btn_search_Click(object sender, EventArgs e)
    {
    	String bResult = boxSearch.Text;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\acap\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
    	con.Open();
    	SqlCommand cmd = new SqlCommand("SELECT * FROM Student where No_ic =@val", con);
        cmd.Parameters.AddWithValue("@val", bResult);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        cmd.ExecuteNonQuery();
        con.Close();
        //dataGridView1.Visible = true;
    }
