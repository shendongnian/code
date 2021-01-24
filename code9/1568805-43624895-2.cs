    // TODO: Parametrized queries?
    public class SQLConnectionHelper
    {
        private readonly string _connectionString;
        // TODO: Parameterless constructor which gets connection string from config?
        public SQLConnectionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        private TResult WithConnection<T>(Func<SQLiteConnection, TResult> func)
        {
            // TODO: try-catch-rethrow-finally here
            using (var connection = new SQLiteConnection(_connectionString))
            {
                _sqliteConnection.Open();
                var result = func(_sqliteConnection);
 
                _sqliteConnection.Close();
                return result;
            }
        }
        public void ConnectExecuteReader(string query, Action<SQLiteDataReader> action)
        {
            WithConnection(conn => {
                var reader = new SQLiteCommand(query, conn).ExecuteReader();
                action(reader);
            });
        }
        public int ConnectExecuteNonQuery(string query)
        {
            return WithConnection(conn => {
                return new SQLiteCommand(query, conn).ExecuteNonQuery();
            });
        }
    }
