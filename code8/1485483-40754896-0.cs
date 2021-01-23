    using(SqlConnection connection = new SqlConnection("Your connection string"))
    {
        string query = "select replace(Location, '-', '') + Line + Qtd  from table";
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
                .....
        }
        connection.Close();
    }
