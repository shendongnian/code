      public SQLiteConnection GetConnection()
		{
			var sqliteFilename = "Test.db3";
			string documentsPath = 
           System.Environment.GetFolderPath(System.Environment.
            SpecialFolder.Personal);
			// Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			var plat = new 
            SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLiteConnection(plat, path);
			// Return the database connection
			return conn;
		}
