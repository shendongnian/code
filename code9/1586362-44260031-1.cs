    SqlDataReader reader = cmd1.ExecuteReader();
    verify = reader.HasRows;
    if (verify)
    {
        ErrorMessage.Text += "Logging in...";
        reader.Read();
    
        this.lblUserId.Text = reader["ID"].ToString();
        //read other data into other labels
    }
    
    con.Close();
