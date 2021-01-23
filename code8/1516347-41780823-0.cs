    using(var connection = new SqlConnection(<<connectionString>>))
    {
    	var sqlQuery = <<Select Query>>;
    	connection.Open();
    	using(var command = new SqlCommand(sqlQuery, connection))
    	{
    		var count = (int) comand.ExecuteScalar();
    		
    		if(count > 0)
    		{
    			//Logic of selecting checkbox in the checkbox list.
    		}
    	}
    }
