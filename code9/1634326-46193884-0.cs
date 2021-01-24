    public class MySqlLiteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }
    }
