    public string GetLastIdFromDatabase()
    {
         int lastIndex;
         string lastID ="";
    
         using (var connection = new MySqlConnection(Configuration.ConnectionString))
    	 using (var command = new MySqlCommand("query", connection))
         {
    		 connection.Open();
    		 MySqlDataReader reader = cmd2.ExecuteReader();
    
    		 while (reader.Read())
    		 {
    			   string item = reader2["ID"].ToString();
    			   lastIndex = int.Parse(item);
    			   lastIndex++;
    			   lastID = lastIndex.ToString();
    		 }	 
    	 }
    	 
         return lastID;
    }
