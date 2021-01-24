    public static class StringExtensions
    {
    	public static string RemoveSoftHyphens(this string input)
    	{
    		var output = new StringBuilder(input.Length);
    		foreach (char c in input)
    		{
    			if (c != 0xAD)
    			{
    				output.Append(c);
    			}
    		}
    		return output.ToString();
    	}
    }
