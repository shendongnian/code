    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] lines = new string[] {
    			"2015-03-08 10:30:00     /user841/column-width",
    			"2015-03-08 10:30:01     /user849/connect",
    			"2015-03-08 10:30:01     /user262/open-level2-price",
    			"2015-03-08 10:30:01     /user839/open-detailed-quotes"
    		};
    		
    		string pattern = @"(.*/.*/)(.*)";
    		
    		string replacement = "$2";
    		
    		foreach(var line in lines)
    		{
    			Console.WriteLine(Regex.Replace(line, pattern, replacement));
    		}
    	}
    }
