    public static dynamic TryGetProperty(this ExpandoObject obj, String propertyName)
    {
	    var dict = (IDictionary<String, Object>)obj;
    	return dict.ContainsKey(propertyName) ? dict[propertyName] : null;
    }
