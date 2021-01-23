     string sql = 
       @"SELECT Marks,
                Id 
           FROM table4";
     using (SqlConnection Connection = new SqlConnection((@"DataSource"))) {
       using (SqlCommand myCommand = new SqlCommand(sql, Connection)) {
         Connection.Open();
         // We don't know the final array's length; let's use a list as buffer  
         List<string[]> buffer = new List<string[]>();
         using (SqlDataReader myReader = myCommand.ExecuteReader()) {
           while (myReader.Read())
             buffer.Add(new string[] {
               Convert.ToString(myReader["id"]),
               Convert.ToString(myReader["Marks"]),
             });
         } 
         return buffer.ToArray(); 
       }         
     }
