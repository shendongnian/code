    static bool TestConnectionString<T>(string connectionString) where T : DbConnection, new()
    {
        using (DbConnection connection = new T())
        {
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
