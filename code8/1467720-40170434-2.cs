    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;
    
    public class Test
    {
    	public static void Main()
    	{
    		string input = @"aaa bbbb; Name=John Lewis; ccc ddd; Age=20;";
        	string pattern = @"(?:.+?; )?(?<Key>.+?)=(?<Value>.+?);";
        
    	    var matches = Regex.Matches(input, pattern);
        	foreach (var match in matches.OfType<Match>())
        	{
        		string key = match.Groups["Key"].Value;
        		string value = match.Groups["Value"].Value;
        		Console.WriteLine(key + ": " + value);
        	}
    	}
    }
