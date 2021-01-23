    public static void BackupDatabase(string fileName)
    {
        using (SQLiteConnection source = new SQLiteConnection("Data Source = YourDatabase.db"))
        using (SQLiteConnection destination = new SQLiteConnection(String.Format("Data Source = {0}", fileName)))
        {
            source.Open();
            destination.Open();
            source.BackupDatabase(destination, "main", "main", -1, null, -1);
        }
    }
