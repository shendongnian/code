    public static NpgsqlConnection Spajanje()
    {
        var conn = new NpgsqlConnection(Connectionstring);
        
    	conn.Open();
        return conn;
    
    }
