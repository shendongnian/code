    public static class StringExtensions
    {
    	public static IEnumerable<string> SplitAsEnumerable(this string source, char splitter)
    	{
            if (source == null)
    		{
    			yield break;
    		}
    		var builder = new StringBuilder();
    		    
    		foreach (char c in source)
    		{
    			if (c != splitter)
    			{
    				builder.Append(c);
    			}
    			else
    			{
    				if (builder.Length > 0)
    				{
    					yield return builder.ToString();
    					builder.Clear();
    				}
    			}
    		}
    	}
    }
