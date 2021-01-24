    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var lst = new List<string> {"3.AAA", "AAA.BBB", "AAA.3.BBB", "AAA.3.B555B", "AAA.3.BBB.4", 
    			"AAA.3.BBB.4.CCC", "AAA.3.BBB.CCC", "AAA.3.BBB.CCC.4", "AAA.3.BBB.CCC.4.DDD",
    			"ZZZ.AAA.3.BBB","ZZZ.AAA.3.BBB.4","ZZZ.AAA.3.BBB.4.CCC", "ZZZ.AAA.3.BBB.CCC",
    			"ZZZ.AAA.3.BBB.CCC.4", "ZZZ.AAA.3.BBB.CCC.4.DDD"};
    		var rx = new Regex(@"^(?:(?!\d+\.)[^\s.]+\.)+\d+(?:\.(?!\d+(?=\.|$))[^\s.]+)+$", 
    			RegexOptions.Compiled | RegexOptions.ECMAScript);
    		foreach (var s in lst) 
    		{
    			if (rx.IsMatch(s))
    				Console.WriteLine(s);
    		}
    	}    	
    }
