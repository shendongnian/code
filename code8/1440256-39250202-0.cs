    public void SaveData(string filename, string jsonobject)
    {
        // define connection string and query
    	string connectionString = "Data Source=.;Initial Catalog=;Integrated Security=True";
    	string query = @"IF EXISTS(SELECT * FROM dbo.T_Pages WHERE pagename = @pagename)
    	                    UPDATE dbo.T_Pages 
    						SET pageinfo = @PageInfo
    						WHERE pagename = @pagename
    					ELSE
    					    INSERT INTO dbo.T_Pages(PageName, PageInfo) VALUES(@PageName, @PageInfo);";
    
    	// create connection and command in "using" blocks
        using (SqlConnection conn = new SqlConnection(connectionString))
    	using (SqlCommand cmd = new SqlCommand(query, conn))
    	{
    	    // define the parameters - not sure just how large those 
            // string lengths need to be - use whatever is defined in the
            // database table here!
    		cmd.Parameters.Add("@PageName", SqlDbType.VarChar, 100).Value = filename;
    		cmd.Parameters.Add("@PageInfo", SqlDbType.VarChar, 200).Value = jsonobject;
    		
    		// open connection, execute query, close connection
    		conn.Open();
    		int rowsAffected = cmd.ExecuteNonQuery();
    		conn.Close();
    	}
    }
    	
