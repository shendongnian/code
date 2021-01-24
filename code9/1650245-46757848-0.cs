    using (var conn = new SqlConnection("your_conn_string"))
    {
    	var command = new SqlCommand("select * from [dbo].[tableName] where 1 = 2");
    	conn.Open();
    
    	using(var dr = command.ExecuteReader())
    	{
    		var columns = new List<string>();
    
    		for(int i=0;i<reader.FieldCount;i++)
    		{
    		   columns.Add(reader.GetName(i));
    		}
    	}
    }
