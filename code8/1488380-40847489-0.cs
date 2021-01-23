	private void CreateDatabase()
    {
        var dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "StoredEvents.sqlite");
        using (SQLiteConnection SQLiteConn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), dbPath, false))
		{
			SQLiteConn.CreateTable<StoredEvents>();
		}     
    }
