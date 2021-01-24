    public SQLiteConnection GetConnection()
    {
        var dbName = "TestDB-DEV.db3";
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string libraryPath = Path.Combine(folder, "..", "Library");
        var path = Path.Combine(libraryPath, dbName);
        var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        var connection = new SQLiteConnection(platform, path);
        return connection;
    }
