    // TODO: Parametrized queries?
    public class SQLConnectionHelper
    {
        private readonly string _connectionString;
        public SQLConnectionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        private TResult WithConnection<T>(Func<SQLiteConnection, TResult> func)
        {
            // TODO: try-catch-rethrow-finally here
            var connection = new SQLiteConnection(_connectionString);
            _sqliteConnection.Open();
            var result = func(_sqliteConnection);
 
            _sqliteConnection.Close();
            return result;
        }
        public void ConnectExecuteReader(string query, Action<SQLiteReader> action)
        {
            return WithConnection(conn => {
                var reader = SQLiteCommand(query, conn).ExecuteReader();
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
