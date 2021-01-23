    public static class CustomNameMap
    {
    	public static void SetFor<T>(string prefix = null)
    	{
    		if (prefix == null) prefix = typeof(T).Name + "_";
    		var typeMap = new CustomPropertyTypeMap(typeof(T), (type, name) =>
    		{
    			if (name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
    				name = name.Substring(prefix.Length);
    			return type.GetProperty(name);
    		});
    		SqlMapper.SetTypeMap(typeof(T), typeMap);
    	}
    }
