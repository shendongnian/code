    _DBConn = new SQLiteConnection(new SQLitePlatformWinRT(), dbpath, 
      // optional - if you want to create new db    
      SQLite.Net.Interop.SQLiteOpenFlags.Create |   
      SQLite.Net.Interop.SQLiteOpenFlags.ReadWrite | 
      SQLite.Net.Interop.SQLiteOpenFlags.FullMutex);
