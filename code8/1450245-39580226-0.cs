    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	    Regex regex = new Regex(@"\d{4}[-]\d{2}[-]\d{2}[ ]\d{2}[:]\d{2}[:]\d{2}[,]\d{3}");
    	    Match match = regex.Match("2012-10-18 15:29:37,886");
    	    if (match.Success)
    	    {
    	        Console.WriteLine("The value is a match.");
    	    }
        }
    }
