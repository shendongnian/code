    public class DbContext
    {
        private static string _connectionString;
        static DbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CTXDB"].ConnectionString;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
