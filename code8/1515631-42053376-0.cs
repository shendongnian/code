    using System;
    using System.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var s = "Foo\r\n    Bar\r\n    Fizz\r\nBuzz\r\nEndOfData\r\nFoo\r\n    Bar\r\n    Fizz\r\nBuzz";
            var res = Regex.Matches(s.Substring(0, s.IndexOf("\nEndOfData\r\n")), @"^(\p{Zs}*)(.*)\r$", RegexOptions.Multiline)
            	.Cast<Match>()
            	.Select(m => new[] { m.Groups[1].Value, m.Groups[2].Value });
            foreach (var v in res)
            		Console.WriteLine("Group 1: '{0}', Group 2: '{1}'", v[0], v[1]);
    	}
    }
