    using System.Text.RegularExpressions;
    ...
    private static Regex leadingTrailingAsterisks = new Regex("(^\\*)|(\\*$)");
	private static string RemoveAllowedAsterisks(string pattern)
	{
	    return leadingTrailingAsterisks.Replace(pattern, "");
	}
