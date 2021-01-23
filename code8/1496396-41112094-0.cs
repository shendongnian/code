    using( var rdr = SQLiteDataReader zReader = DBUtils.getAction(dbPath, 1))
    {
      if( rdr.Read() )
      {
         var someString = rdr.GetString(0);
         ...
      }
    }
 
