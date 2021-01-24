    public SQLiteConnection GetConnection()
    {
         var dbName = "TestDB-DEV.db3";
         var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
         var path = Path.Combine(documentsPath, dbName);
    
         var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
         var connection = new SQLiteConnection(platform, path);
    
         return connection;
     }
