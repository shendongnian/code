    List<QueryResult> results = new List<QueryResult>();
    
    using(SqlConnection conn = new SqlConnection(ConnectionString))
    {
    	conn.Open();
    	using(SqlCommand cmd = new SqlCommand(query, conn)
    	{
    		cmd.Parameters.AddWithValue("@eventId", event_id);
    		var reader = cmd.ExecuteReader();
    		
    		if(reader.HasRows())
    		{
    			while(reader.Read())
    			{
                    QueryResult result = new QueryResult();
    				result.EventId = (int)reader["id"];
    				result.Number = (int)reader["number"];
    				result.Capacity = (int)reader["capacity"];
                    results.Add(result);
    			}
    		}
    	}
    }
