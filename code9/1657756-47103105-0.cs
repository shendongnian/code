    public class AndroidSqliteConnectionService : ISqliteConnectionService
    {
        private const string FileName = "File.sqlite3";
        private SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            if (_connection == null)
            {
                var databaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var databaseFilePath = Path.Combine(databaseFolder, FileName);
                _connection = new SQLiteAsyncConnection(databaseFilePath);
            }
            return _connection;
        }
    }
