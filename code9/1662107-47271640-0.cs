    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
    	public static void Main()
    	{
    		var pattern = @"(^\d{1,4} - \d{1,4}).*";
    		string input = ("1000 - 1009 ABC1 ABC SOMETHING ELSE");
    		string replacement = "$1";
    		string result = Regex.Replace(input, pattern, replacement);
            Console.WriteLine(result);
    	}
    }
