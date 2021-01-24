    bool TestConnection<T>(string connectionString) where T : IDbConnection, new
    {
        using(T con = new T())
        {
            con.ConnectionString = connectionString;
            connection.Open();
            return true;
        }
    }
