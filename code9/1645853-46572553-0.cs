    using(var connection = new SqlConnection(cs)
    {
        // SELECT 1 because we don't care about the returned data
    	using(var cmd = new SqlCommand($"SELECT 1 FROM [Bidders] WHERE saleID={onsaleID} AND BidderStatus='Winner'", connection))
    	{
    		cmd.CommandType = CommandType.Text;
    		
    		using(var reader = cmd.ExecuteReader())
    		{
    			if(reader.Read())
    			{
    				// The command returned rows (there is an existing winner for the given `onsaleID`)
    			}
    			else
    			{
    				// The command returned no rows.  There is no winner.
    			}
    		}
    	}
    }
