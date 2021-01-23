    public static DataTable GetDataTable(SqlCommand command, IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
    {
        using (new LoggingStopwatch("Executing SQL " + command.CommandText, command.Parameters))
        {
            using (var connection = new SqlConnection(connectionString))
            using (var dataAdapter = new SqlDataAdapter(command))
            {
                command.Connection = connection;
                command.CommandTimeout = ShopexConfiguration.SqlTimeout;
                connection.Open();
                var transaction = connection.BeginTransaction(isolationLevel);
                command.Transaction = transaction;
                try
                {
                    var result = new DataTable();
                    dataAdapter.Fill(result);
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        //
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                    }
                    finally { connection.Close(); }
                    throw;
                }
            }
        }
    }
