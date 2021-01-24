    public class DbContext
    {
        private static readonly string _connectionString;
        static DbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CTXDB"].ConnectionString;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
