    try {
     myConn.Open();
    
     using(SQLiteCommand sqCommand = new SQLiteCommand(sql, myConn)) {
      sqCommand.CommandText = sql;
      object result = sqCommand.ExecuteScalar();
      return result != null ? result.ToString() : "";
     }
    } catch (Exception e) {
     // do exception handling
    }
