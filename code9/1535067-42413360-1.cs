    using (SqlCommand command = new SqlCommand(queryString, connection))
    {
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            // ...
        }
    }
