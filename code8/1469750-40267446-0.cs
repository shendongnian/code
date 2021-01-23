    SqlConnection connection = null;
    var runBatch = false;
    try
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        // 1st batch
        command.CommandText = "BEGIN TRANSACTION";
        command.ExecuteNonQuery();
        // 2nd batch
        command.CommandText = "UPDATE MyTable SET MyColumn = 'foo' WHERE Name = @name";
        command.Parameters.AddWithValue("name", "bar");
        command.ExecuteNonQuery();
        // 3rd batch
        command.CommandText = "COMMIT TRANSACTION";
        command.Parameters.Clear();
        command.ExecuteNonQuery();
    }
    finally
    {
        if (connection != null)
        {
            connection.Close();
        }
    }
