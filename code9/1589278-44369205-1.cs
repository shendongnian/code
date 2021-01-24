     //TODO: put the right connection here
     using (OracleConnection con = new OracleConnection(ConnectionStringHere)) {
       con.Open();
       string sql = 
         @"BEGIN -- Anonymous block: run these queries (update, commit) together
             UPDATE table_name 
                SET columnname1 = 'N', 
                    columnname2 = 1
              WHERE columnname3 = '-2085371064'; -- Is it really a string?
             COMMIT; -- Not necessary, but possible
           END;";
       using (var q = con.CreateCommand()) {
         q.CommandText = sql;
         q.ExecuteNonQuery();   
       } 
     }
