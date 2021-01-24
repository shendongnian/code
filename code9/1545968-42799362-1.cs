    public class MySqlConnectionFactory: IDbConnectionFactory {
        public IDbConnection CreateConnection() {
            return new MySqlConnection("connection string");
        }
    }
