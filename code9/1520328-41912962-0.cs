    searchStringList.Select(s => s.SubstringAsFarAsIndexOfAny(subStringList));
    	
    public static class stringExt
    {
    	public static int IndexOfAny(this string s, IEnumerable<string> anyOf, StringComparison stringComparisonType=StringComparison.CurrentCultureIgnoreCase) 
    	{
    		var founds= anyOf.Select(sub=> s.IndexOf(sub,stringComparisonType)).Where(i => i>=0);
    		return founds.Any() ? founds.Min() : -1;
    	}
    	
    	public static string SubstringAsFarAsIndexOfAny(this string s, IEnumerable<string> anyOf, StringComparison stringComparisonType=StringComparison.CurrentCultureIgnoreCase)
    	{
    		var foundIndex= s.IndexOfAny(anyOf,stringComparisonType);
    		return foundIndex >=0 ? s.Substring(0, foundIndex) : s;
    	}
    }
