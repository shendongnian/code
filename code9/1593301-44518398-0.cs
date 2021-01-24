    string queryString = "select Col_Length('Contents','Title') as columnLengthh";
    string connectionString = "Your connection string";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        var result = command.ExecuteScalar();
        Console.WriteLine("columnLengthh = {0}", result);
    }
