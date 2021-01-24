    using System.Text.RegularExpressions;
    public static string GetNiceName(string testString)
    {
    	var pattern = "([A-Z][a-z]+)|([A-Z]+)";
    	var result = new List<string>();
    	foreach (Match m in Regex.Matches(testString, pattern))
    	{
    		result.Add(m.Groups[0].Value);
    	}
    	return string.Join(" ", result);
    }
