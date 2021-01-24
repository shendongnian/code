    using System;
    using System.Collections.Generic;	
    using System.Text.RegularExpressions;
    public class Program
    {
    	public static void Main()
    	{
    		var substrings = Regex.Split("ABCD232ERE44RR", @"[^A-Z0-9]+|(?<=[A-Z])(?=[0-9])|(?<=[0-9])(?=[A-Z])");
    		Console.WriteLine(string.Join(",",substrings));
    	}
    }
    Output : ABCD,232,ERE,44,RR
