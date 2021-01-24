    using (SqlConnection conn = new SqlConnection(MainData.ConnStr))
    {
        conn.Open();
        using (SqlCommand com = new SqlCommand("select * from MY_TABLE", conn))
        using (SqlDataReader reader = com.ExecuteReader())
        {
            // check if query returned any rows, if so, loop through them
            if (reader.HasRows)
                while (reader.Read())
                {
                     //here you can do operations on table rows, like assigning to variables etc.
                }
                    
        }
    }
            
