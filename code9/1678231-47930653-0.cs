    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string input = "((isoCode=s)||(isoCode=a))&&(title=s)&&((ti=2)&&(t=2))||(t=2&&e>5)";
    	    string pattern = @"\(((?>\((?<DEPTH>)|\)(?<-DEPTH>)|.?)*(?(DEPTH)(?!)))\)|&{2}|\|{2}";
    	    MatchCollection matches = Regex.Matches(input, pattern);
    	    foreach (Match match in matches)
    	    {
    	        Console.WriteLine(match.Groups[1].Success ? match.Groups[1].Value : match.Groups[0].Value);
    	    }
    	}
    }
