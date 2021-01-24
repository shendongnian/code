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
        //Open sqlite StorageFile
        private static string dbfilePath = string.Empty;
        private async static Task<string> DBFilePathAsync(StorageFile sqliteStorageFile)
        {
            if (string.IsNullOrEmpty(dbfilePath))
            {
                var folder = await sqliteStorageFile.GetParentAsync();
                dbfilePath = Path.Combine(folder.Path, sqliteStorageFile.Name);
            }
            return dbfilePath;
        }
        /// <summary>
        /// Open sqlite storagefile.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async static Task<SQLiteConnection> DbConnectionStorageFileAsync(StorageFile sqliteStorageFile)
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), await DBFilePathAsync(sqliteStorageFile));
        }
   
