    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.IO;
    public class Test
    {
    	// Demo: https://regex101.com/r/M9iGUO/2
    	public static readonly Regex reg = new Regex(@"^h(\d+)\.+\s*(.+)", RegexOptions.Compiled | RegexOptions.Multiline); 
    	
    	public static void Main()
    	{
    		var inputText = "h1. Topic 1\r\nblah blah blah, because of bla bla bla\r\nh2. PartA\r\nblah blah blah\r\nh3. Part a\r\nblah blah blah\r\nh2. Part B\r\nblah blah blah\r\nh1. Topic 2\r\nand its cuz blah blah\r\nFIN";
    		var res = ProcessHeadersInText(inputText, 2);
    		Console.WriteLine(res);
    	}
    	public static string ProcessHeadersInText(string inputText, int atLevel = 1) 
    	{
    		return reg.Replace(inputText, m =>
    			string.Format("<h{0}>{1}</h{0}>", (int.Parse(m.Groups[1].Value) > 9 ?
    				9 : int.Parse(m.Groups[1].Value) + atLevel), m.Groups[2].Value.Trim()));
    	}
    }
