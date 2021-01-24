    using (var connection = new MySqlConnection("[MySQL_connection_string]"))
    {
        try
        {
            connection.Open();
            using (var command = new MySqlCommand("[procedure_name]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                // add parameters here
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // reading data from database
                }
                // other stuff
            }
            connection.Close();
        }
        catch (Exception e)
        {
            // handle exceptions here
        }
    }
