     using (MySqlConnection con = new MySqlConnection(YourCOnnectionString)) {
       con.Open();
       using (MySqlCommand cmd = new MySqlCommand()) {
         cmd.Connection = con;
         cmd.CommandText =
           $@"SELECT * 
                FROM chat 
               LIMIT {cCfirst}, {cClast}";
         using (var reader = cmd.ExecuteReader()) {
           while (reader.Read()) {
             //TODO: put relevant code here
           }
         }
       }  
     }
