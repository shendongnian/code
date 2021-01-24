    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        using (SqlCommand command = new SqlCommand("MyStoredProcedure", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
    
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    item.message = reader.GetString(0);
                }
                reader.Close();
            }
        }
    
    }
