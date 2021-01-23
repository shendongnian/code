    var result = new Dictionary<string, object>();
    
    using (var reader = new JsonTextReader(new StringReader(yourJsonStr))
    {
    	var lastProp = string.Empty;
    	try
    	{
    		while (reader.Read())
    		{
    			if (reader.TokenType == JsonToken.PropertyName)
    			{
    				lastProp = reader.Value.ToString();
    			}
    			
    			if (reader.TokenType == JsonToken.Integer || 
                    reader.TokenType == JsonToken.String)
    			{
    				result.Add(lastProp, reader.Value);
    			}
    		}
    	}
    	catch
    	{
    	    //to do nothing
    	}
    }
