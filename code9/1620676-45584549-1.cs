    using (command = new SqlCommand("sp", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddRange(parameters);
        using (var reader = command.ExecuteReader())
        {
            while (reader.HasRows)
            {
                while(reader.Read())
                {
                
                }
                reader.NextResult();
            }
        }
    }
