    public static class DictionaryExtensions
    {
    	public static string ToCsvFormat<TK,TV>(this IDictionary<TK,TV> dict)
    	{
    		var sw = new StringWriter();
    		foreach(var kv in dict)
    		{
    			sw.WriteLine($"{kv.Key}, {kv.Value}");
    		}
    		return sw.ToString();
    	}
    }
