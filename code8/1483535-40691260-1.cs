    public static void BackupDatabase(string sourceFile, string destFile)
    {
        using (SQLiteConnection source = new SQLiteConnection(String.Format("Data Source = {0}", sourceFile)))
        using (SQLiteConnection destination = new SQLiteConnection(String.Format("Data Source = {0}", destFile)))
        {
            source.Open();
            destination.Open();
            source.BackupDatabase(destination, "main", "main", -1, null, -1);
        }
    }
