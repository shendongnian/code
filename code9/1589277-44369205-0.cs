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
       //TODO: put the right command type
       using (var q = new OracleCommand(sql)) {
         q.Connection = con;
         q.ExecuteNonQuery();   
       } 
     }
