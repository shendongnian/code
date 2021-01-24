    using (SqlCommand command = new SqlCommand("SELECT * FROM table WHERE criteria IN (@placeholder,@placeholder2)", connection))
    {
        command.Parameters.AddWithValue("@placeholder", 1);
        command.Parameters.AddWithValue("@placeholder2", 2);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                        
            }
        }
    }
