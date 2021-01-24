    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string str = "you androids don't exactly cover for each other in times of stress. i think youre right it would seem we lack a specific talent you humans possess i believe it's called empathy"; 
    		var sList = new List<string> {"for each other",  "talent", "you humans"};
    		
    		var searchPattern = string.Join("|", sList.Select(i => i.Replace("|", "\\|")));
    		
    		var splitRegex = new Regex(searchPattern);
    		
    		var matches = splitRegex.Matches(str);
    		
    		var lastMatchPosition = 0;
    		
    		foreach(Match match in matches)
    		{
    			if(lastMatchPosition != match.Index)
    			{
    				WriteTrimmed(str.Substring(lastMatchPosition, match.Index - lastMatchPosition));
    			}
    
    			WriteTrimmed(match.Value);
    			lastMatchPosition = match.Index + match.Length;
    		}
    		
    		if (lastMatchPosition < str.Length - 1)
    		{
    			WriteTrimmed(str.Substring(lastMatchPosition));
    		}
    	}
    	
    	private static void WriteTrimmed(string str)
    	{
    		str = str.Trim();
    		if (!string.IsNullOrWhiteSpace(str))
    		{
    			Console.WriteLine(str);
    		}
    	}
    }
