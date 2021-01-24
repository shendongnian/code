    public string SortInnerArrays(JObject jObj, string innerKey)
    {
    	foreach (var prop in jObj.Properties())
    	{
    		if (prop.Value.Type == JTokenType.Array)
    		{
    			var vals = prop.Values()
    				.OfType<JObject>()
    				.OrderBy(x => x.Property(innerKey).Value.ToString())
    				.ToList();
    			prop.Value = JContainer.FromObject(vals);
    		}
    	}
    
    	return jObj.ToString(Formatting.Indented);
    }
