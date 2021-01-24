    static void Main(string[] args)
    {
    
    	var data = new List<dynamic>();
    	List<string> cols = default;
    
    	using (var conn = new SqlConnection(connStr))
    	{
    		conn.Open();
    		using (var comm = new SqlCommand("SELECT * FROM dbo.Client", conn))
    		{
    			using (var reader = comm.ExecuteReader())
    			{
                    // Get columns names
    				cols = Enumerable.Range(0, reader.FieldCount)
    					   .Select(i => reader.GetName(i)).ToList();
    				while (reader.Read())
    				{
    					dynamic obj = new Dynamo();
    					cols.ForEach(c => obj[c] = reader[c]);
    					data.Add(obj);
    				}
    			}
    		}
    	}
    
    
    	/* OUTPUT DATA */
    
    	// To get columns names, you can:
    	// 1) use ready "cols" variable
    	// 2) use "GetDynamicMemberNames()" on first object:
    	//    IEnumerable<string> cols = data[0].GetDynamicMemberNames();
    	foreach (var obj in data)
    	{
    		Console.WriteLine(String.Join(", ", cols.Select(c => $"{c} = {obj[c]}")));
    	}
        
        // Output:
        // ClientId = 1, ClientName = Client1
        // ClientId = 2, ClientName = Client2
    
    }
