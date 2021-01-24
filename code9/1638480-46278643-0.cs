    public static string GetString<T>(IEnumerable<T> items)
    {
    	if (typeof(T) == typeof(Material))
    	{
    		foreach (var material in items.Cast<Material>())
    		{
    		}
    	}
    	if (typeof(T) == typeof(Movement))
    	{
    		foreach (var material in items.Cast<Movement>())
    		{
    		}
    	}
       
    	return "...";
    }
