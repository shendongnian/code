    using System;
    using System.Text.RegularExpressions;
    		
    public class Program
    {
    	public static void Main()
    	{
    		var text = @"a1some textb2";
            var pattern = @"\s?(a1|b2|c1|d2)\s?";
            var replaced = Regex.Replace(text, pattern, " $1 ");
    		
    		Console.WriteLine(replaced);
    		
    	}
    }
