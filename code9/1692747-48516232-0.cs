    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program1
    {
    	public static void Main()
    	{
    		var stringLists = new List<List<string>>{
    			new List<string> {"a", "b", "c"}, 
    			new List<string> {"e", "b", "c"}, 
    			new List<string> {"a", "b", "c"}
    		};
    
    		var prt = stringLists
    			.Select(l => string.Join(",", l))      // make it a string separated by ,
    			.Distinct()                            // distinct it using string.Distinct()
    			.Select(l => l.Split(',').ToList());   // split it again at , and make it List
    
    		foreach (var p in prt)
    		{
    			foreach (var c in p)
    				Console.WriteLine(c);
    			
    			Console.WriteLine();			
    		}	
    	}
    }
