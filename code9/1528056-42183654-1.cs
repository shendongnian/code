    public class MyConnectionFactory
    {
        public DbConnection Create(string serverType, string connectionString)
        {
           if (serverType == "sqlite") return new SqliteConnection(connectionString);
           else if (serverType == "sqlserver") return new SqlConnection(connectionString);
           
           throw new ArgumentException($"{serverType} not supported");
        }
    }
