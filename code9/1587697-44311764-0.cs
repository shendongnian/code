    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var dictionary1 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    		dictionary1.Add("hello", "Hi");
    		dictionary1.Add("world", "people");
    		dictionary1.Add("apple", "fruit");
    		
    		
    		string input = "<a>hello</a> <b>hello world</b> <c>I like apple</c>";
    		string pattern = ("(?<=>)(.)?[^<>]list|" + GetKeyList(dictionary1) + "(?=</)");
    		Regex match = new Regex(pattern, RegexOptions.IgnoreCase);
    		MatchCollection matches = match.Matches(input);
    		
    		string output = "";
    		
    		output = match.Replace(input, replace => {
    			Console.WriteLine(" - " + replace.Value);
    			
    			return dictionary1.ContainsKey(replace.Value) ? dictionary1[replace.Value] : replace.Value;
    		});
    		Console.WriteLine(output);
    	}
    	
    	private static string GetKeyList(Dictionary<string, string> list)
    	{
    		 return string.Join("|", new List<string>(list.Keys).ToArray());
    	}
    }
