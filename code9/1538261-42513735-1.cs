	using System;
	using System.Text.RegularExpressions;
					
	public class Program
	{
		public static string Quoterize(string s)
    	{
        	return Regex.Replace(s, @"\w+", match => "\"" + match + "\"");
    	}
	
		public static string RewriteThisPlease(string s)
   		{
			return s
				.Replace("\n", "," + Environment.NewLine)
				.Replace(" ", "")
				.Replace(Environment.NewLine, "")
				.Replace("{,", "{")
				.Replace(",}", "}");
    	}
	
		public static void Main()
		{
			var k = @""; // your file goes here
			Console.WriteLine("{"+MoveToRegexPlease(Quoterize((k).Replace("{", ": {")))+"}");
		}
	}
