    string connstring = "Server='server1';Port='5432';User Id='myUser';Password='myPW;Database='myDatabase';";
    
    // connect to Database              
    NpgsqlConnection conn = new NpgsqlConnection(strConnection);
    conn.Open();
    
    try
    {               
    	// SQL-Command
    	string strSQL = "SELECT * FROM yourTable";
    
    	NpgsqlCommand cmd = new NpgsqlCommand(strSQL, conn);
    	NpgsqlDataReader dbReader = null;
    	dbReader = cmd.ExecuteReader();
    
    	while (dbReader.Read())
    	{
    		Console.WriteLine(dbReader.GetValue(0).ToString());
    	}
    
    }
    finally
    {
    	conn.Close();
    }
