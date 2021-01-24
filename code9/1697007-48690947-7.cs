    List<double> ParseFoo(string jsonString)
    {
    	var data1 = new JavaScriptSerializer().Deserialize<Bar>(jsonString).value;
    	var r = new List<double>();
    
    	// We can handle a single value, an array, or an array of arrays:
    	var array = data1 as object[];
    	if (array != null)
    	{
    		foreach (object obj in array)
    		{
    			decimal? number = obj as decimal?;
    			if (number.HasValue)
    				r.Add((double)number.Value);
    			else
    				r.AddRange((obj as object[]).Cast<decimal>().Select(d => (double)d));
    		}
    	} else
    	{
    		r.Add((double)data1);
    	}
    	
    	return r;
    }
