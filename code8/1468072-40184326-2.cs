    public static class StringExtensions
    {
    	public static bool Contains(this string source, string toCheck)
    	{
    		return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
    	}
    }
