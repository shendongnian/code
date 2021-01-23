    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
     
    public class Test
    {
    	public static void Main()
    	{
        	var pattern = @"\b(?:(?:0*(?<h>\d+):)?0*(?<m>\d+):)?0*(?<d>\d+)\b";
        	var strs = new List<string>() {"07", "09:07", "058:09:07" };
        	foreach (var s in strs)
        	{
        		var result = Regex.Replace(s, pattern, m =>
        			m.Groups["h"].Success && m.Groups["m"].Success ? 
        				string.Format("{0}h {1}m {2}d", m.Groups["h"].Value, m.Groups["m"].Value, m.Groups["d"].Value) :
        			m.Groups["m"].Success ? 
        				string.Format("{0}m {1}d", m.Groups["m"].Value, m.Groups["d"].Value) :
        					string.Format("{0}d", m.Groups["d"].Value) 
        		);
       	    	Console.WriteLine(result);
        	}
    	}
    }
