    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        connection.Open();
        OracleCommand command = connection.CreateCommand();
        OracleTransaction transaction;
        transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        command.Transaction = transaction;
        try
        {
            command.CommandText = 
                "UPDATE table_name    SET columnname1 = 'N',        columnname2 = 1 WHERE columnname3 = '-2085371064';";
            command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine(e.ToString());
        }
    }
