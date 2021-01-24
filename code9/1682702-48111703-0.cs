    using (var conn = new SqlConnection("blah"))
    {
    	using (var cmd = new SqlCommand("blah"))
    	{
    		using (var dr = cmd.ExecuteReader())
    		{
    
    		}
    	}
    }
