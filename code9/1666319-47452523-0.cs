    using(var sq_connection = (IDbConnection)a.CreateInstance("System.Data.SQLite.SQLiteConnection"))
    {
        sq_connection.ConnectionString = "Con...";
        using(var sq_command = sq_connection.CreateCommand())
        {
            sq_command.CommandText = sql;
            // execute
        }
    }
