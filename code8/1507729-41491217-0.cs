     var sqlQuery = "UPDATE StockUpdateQueue SET Synced = 1, SyncedAt = GETDATE() WHERE Id IN (@p0,@p1);";
     var sqlParamters = new Dictionary<string, object>()
     {
          { "@p0", 12345 },
          { "@p1", 65432 }
     };
     SqlCommand mySqlCommand = new SqlCommand(sqlQuery , conSQL); // conSQL is the connection
     foreach (KeyValuePair<string, object> sqlParamter in sqlParamters)
     {
        mySqlCommand.Parameters.AddWithValue(sqlParamter .Key, sqlParamter.Value);
     }
     mySqlCommand .ExecuteNonQuery();
     
