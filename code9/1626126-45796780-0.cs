    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "mySQLite.db"); // change mySQLite.db for your SQLite db filename
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
