    private Datatable ExecuteSqlQuery<TConnection, TCommand>(string connectionString, string sqlQuery)
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new() 
    {
        using (DbConnection connection = new TConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            TCommand cmd = new TCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = connection;
            var queryData.Load(cmd.ExecuteReader());
        }
    }
