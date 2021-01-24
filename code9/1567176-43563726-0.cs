    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    					
    public class Test
    {
    	public static void Main()
    	{
    		var regex = @"[0-9]+|\b(?:\p{Lu}+\b|\w)";
    		var list = new List<string> {"Freestyle steel","Freestyle Alloy","Trekking steel uk","Single speed","5 speed","15 speed","3 Speed internal gear with 55 coaster","MTB steel","Junior MTB"};
    		foreach(var data in list)
    		{
    			var matches = Regex.Matches(data, regex).Cast<Match>().Select(m => m.Value.ToUpper());
    			Console.WriteLine(string.Join("", matches));
    		}
    	}
    }
