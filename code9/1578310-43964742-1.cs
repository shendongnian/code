        String query =  @"SELECT temp
            FROM TableName
            ORDER BY Id DESC
            LIMIT 1";
    
         string connString = "Server=localhost; Database=myDatabaseName; 
     Trusted_Connection=Yes";
            
       SQLiteConnection connection = new SQLiteConnection(connString);
    SQLiteDataAdapter da = new SQLiteDataAdapter(query, connection);
        
    
    DataSet ds = new DataSet();
    
