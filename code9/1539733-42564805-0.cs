    string connectionString = "";
    using (var connection = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand
        {
            CommandText = @"select * from Usuario where Username = @login and Password = CONVERT(VARCHAR(32), HASHBYTES('MD5', @pass), 2)",
            CommandType = CommandType.Text,
            Connection = connection
        })
        {
            command.Parameters.Add(new SqlParameter("login", SqlDbType.VarChar, 50) { Value = "test" });
            command.Parameters.Add(new SqlParameter("pass", SqlDbType.VarChar, 50) { Value = "test" });
            connection.Open();
            using (var dataReader = command.ExecuteReader())
            {
                // do some stuff
            }
        }
    }
