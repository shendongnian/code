    public static class DatabaseManager
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection(new SQLitePlatformWinRT(), "MusicAppM.db");
        // private static StorageFile db = null;
    
        public static async void CreateMobileDB()
        {
            StorageFile db = null;
            // StorageFolder folder = KnownFolders.RemovableDevices;
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            await RetrieveDbInFolders(db, folder, (parm) =>
                { db = parm; });
            if (db != null)
            {
                SQLiteConnection dbConnection = new SQLiteConnection(new SQLitePlatformWinRT(), db.Path);
            }
            else
            {
                string ConnString = Path.Combine(folder.Path, "MusicAppM.db");
                SQLiteConnection dbConnection = new SQLiteConnection(new SQLitePlatformWinRT(), ConnString);
            }
        }
    
        private static async Task RetrieveDbInFolders(StorageFile db, StorageFolder parent, Action<StorageFile> callback = null)
        {
            foreach (var item in await parent.GetFilesAsync())
            {
                if (item.FileType == ".db")
                    db = item;
                callback(db);
            }
            foreach (var item in await parent.GetFoldersAsync())
            {
                await RetrieveDbInFolders(db, item);
            }
        }
    }
