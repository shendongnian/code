    public static SQLiteDataReader getAction(string dbPath, byte actionLevel)
    {
       SQLiteDataReader reader = null;
    
       SQLiteConnection  m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;FailIfMissing=True");
     
        m_dbConnection.Open();
    
        string sql = "SELECT * FROM Actions WHERE acLevel=" + actionLevel + " ORDER BY RANDOM() LIMIT 1";
       SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection)   
    
        reader = command.ExecuteReader();
        return reader;  
    }
