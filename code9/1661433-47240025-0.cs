    try {
     myConn.Open();
    
     using(SQLiteCommand sqCommand = new SQLiteCommand(sql, myConn)) {
      sqCommand.CommandText = sql;
      SQLiteDataReader reader = sqCommand.ExecuteReader();
      if(reader.Read())
         return reader.GetString(0);
      else
         return ""; // or whatever you want to return if no records are present
     }
    } catch (Exception e) {
     // do exception handling
    }
