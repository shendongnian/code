    private void Recompute()
    {
    	using(clsDBConn dbConn = new clsDBConn())
    	{
    		using(SqlDataCommand CMD = new SqlCommand("SELECT * FROM tblEmployee", dbConn.connection))
    		{
    			CMD.CommandTimeout = 120;
    			using(SqlDataReader EmplReader = CMD.ExecuteReader())
    			{
    				while (EmplReader.Read())
    				{
    					while(DateFrom >= DateTo)
    					{
    						//Some Reader 
    						//Lots of SQL Command ExecuteNonQuery();
    					}
    				}
    			}
    		}
    	}
    }
