    public class DBConnection
    {
        private readonly string connectionString;
    
        public DBConnection(AppSettings settings)
        {
            this.connectionString = settings.WarehouseConnectionString;
        }
    
        public SqlConnection GetConnection()
        {
            return new SqlConnection(this.connectionString);
        }
    }
