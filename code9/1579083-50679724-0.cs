    public class MyProviderFactory : IDbConnectionFactory
    {    
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            if ("mySqlName".equals(nameOrConnectionString))
            {
                return new MySqlConnection("<Connection String>");
            }
            else 
            {
                return new SqlConnection("<Connection String>");
            }
        }
    }
