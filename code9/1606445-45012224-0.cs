    string ds = @"Data Source";
    using (SqlConnection con = new SqlConnection(ds))
    {
        string query = "SELECT Salt FROM [Table] WHERE (Login=@Login)";
        string uname = logTXT.Text;              
    
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();    
            cmd.Parameters.AddWithValue("@Login", uname);
            SqlDataReader dr = cmd.ExecuteReader();   
            string salt = null;
            if (reader.Read())
            {
                salt = reader[0];
            }    
        }
    }
