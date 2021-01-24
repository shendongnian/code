    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		var line = "TEST-END : 2017-01-08 15:51 PROGRAM : TLE8888QK-B2 BAU-NR : 95187193";
    		 
    		Regex re = new Regex(@"^(?:TEST-END : )(.*?\d{4}-\d{2}-\d{2} \d{2}:\d{2})");
    		
    		var match = re.Match(line);
    		
    		Console.WriteLine(match.Groups[1]);    		
    		
    		Console.ReadLine(); // leave console open
    	}
    }
