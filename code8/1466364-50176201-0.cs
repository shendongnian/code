    public static int Delete(string url)
    {
        using (var databaseManager = DatabaseManager.Instance)
        {
            lock (databaseManager)
            {
                return databaseManager.Database.Table<File>().Delete(x => x.Url == url);
            }
        }
    }
