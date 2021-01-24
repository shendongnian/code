    private static void FetchChunk(int retries, KeyValuePair<List<dynamic>, Type>[] fetchfields)
    {
    	try
    	{
    		foreach (var chunk in fetchfields)
    		{
    			var method = typeof(DBRepository).GetMethod("GetAll");
    			var Generic = method.MakeGenericMethod(chunk.Value);
    			chunk.Key.AddRange(Generic.Invoke(null, null) as IEnumerable<dynamic>);
    		}
    	}
    	catch
    	{
    		//do stuff } }
    	}
    }
