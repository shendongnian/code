    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q69PRF4;Initial Catalog=new;Integrated Security=True");
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        string str = "select [StID] from StRecords where StID = @stdId;";
        SqlCommand com = new SqlCommand(str, con);
        com.Parameters.AddWithValue("@stdId", Session["login"]);        
        Label11.Text = com.ExecuteScalar().toString();
    }
