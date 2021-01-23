    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var line = " .2 1..2 .0......2.";
    		Console.WriteLine(Regex.Replace(line, "(?<!\\.)\\.{6}(?!\\.)", 
    			m => string.Join("999", m.Value.Select(Char.ToString)) ));
    	}
    }
