        public SQLiteAsyncConnection GetConnection()
        {
            var fileName = "DatabaseName.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteAsyncConnection(path);
            return connection;
        }
