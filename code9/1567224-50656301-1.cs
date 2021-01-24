    private static string dbPath = string.Empty;
        private static string DBPath(string fileName)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
            }
            return dbPath;
        }
        /// <summary>
        /// Get fileName From LocalFolder. Please Create first a dataBase.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SQLiteConnection DbConnection(string fileName)
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), DBPath(fileName));
        }
