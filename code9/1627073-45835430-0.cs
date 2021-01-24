    sqlconn.Open();
    
    SqlCommand com = new SqlCommand("SELECT Email, Badge, Name FROM PublishedWorks", sqlconn);
    
    using (SqlDataReader reader = com.ExecuteReader())
    {
        while (reader.Read())
        {
            // you can create another method to insert and call it from here
        }
    }
