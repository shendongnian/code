    using (SqlConnection sqlConnection = new SqlConnection("connstring"))
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT * FROM YourTable", sqlConnection);
        sqlConnection.Open();
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
    
        while (sqlReader.Read())
        {
            ComboBox1.Items.Add(sqlReader["name"].ToString());
        }
    
        sqlReader.Close();
    }
