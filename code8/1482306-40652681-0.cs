    using (var connection = new SqliteConnection("" +
        new SqliteConnectionStringBuilder
        {
            DataSource = "hello.db"
        }))
    {
        connection.Open();
    
        using (var transaction = connection.BeginTransaction())
        {
            var insertCommand = connection.CreateCommand();
            insertCommand.Transaction = transaction;
            insertCommand.CommandText = "INSERT INTO message ( text ) VALUES ( $text )";
            insertCommand.Parameters.AddWithValue("$text", "Hello, World!");
            insertCommand.ExecuteNonQuery();
    
            var selectCommand = connection.CreateCommand();
            selectCommand.Transaction = transaction;
            selectCommand.CommandText = "SELECT text FROM message";
            using (var reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var message = reader.GetString(0);
                    Console.WriteLine(message);
                }
            }
    
            transaction.Commit();
        }
    }
