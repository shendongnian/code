    private SqlConnection NewDatebaseConnection(string databaseName)
        {
            SqlConnection  connection = new SqlConnection(_connectionString);
            connection.ChangeDatabase(databaseName);
            return SqlConnection;  
        }
