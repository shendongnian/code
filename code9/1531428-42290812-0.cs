    try
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        var trans = connection.BeginTransaction(); 
        using (var command = connection .CreateCommand())
        {
            command.Transaction = trans;
            command.CommandText = "...";
            command.ExecuteNonQuery();
        }
        // other commands may be defined here
        // command can be included or excluded from transaction (do not set Transaction property)
        // commits the transaction
        trans.Commit(); 
    }
    // best practice is to catch specific exception types like `SqlException`
    catch (Exception ex) //error occurred
    {
        trans.Rollback();
        // log error somewhere
    }
    finally
    {
        // execute no-matter what
    }
