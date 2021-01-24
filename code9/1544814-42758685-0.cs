    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
        	var s = "<a href=\"/url?q=https://www.google.com/&amp;sa=U&amp;ved=0ahUKEwizwPy0yNHSAhXMDpAKHec7DAsQFgh6MA0&amp;usg=AFQjCNEjJILXPMMCNAlz5MN1IIzjpr79tw\">";
        	var pattern = @"<a href=""/url\?q=(.*?)&amp;";
        	var result = Regex.Match(s, pattern);
            if (result.Success)
            	Console.WriteLine(result.Groups[1].Value);
    	}
    }
