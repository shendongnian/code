    public void ClearTable<TType>()
    {
        try
        {
            using (var connection = new SQLiteConnection(platform, dbPath))
            {
                connection.DropTable<TType>();
                connection.CreateTable<TType>();
            }
        }
        catch (SQLiteException ex)
        {
            Log.Info("SQLiteEx", ex.Message);
        }
    }
