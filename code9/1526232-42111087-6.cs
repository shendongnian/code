    public static class StringExtensions
    {
    	public static IEnumerable<string> SplitBySpace(this string value)
    	{
    		return value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    	}
    }
