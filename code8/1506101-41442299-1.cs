    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Test
    {
    	public static void Main()
    	{
    		var testData = new List<List<int>>
    		{
    		     new List<int> { 1, 2, 3 },
		         new List<int> { 2, 1, 3 },
		         new List<int> { 6, 8, 3, 45,48 },
		         new List<int> { 9, 2, 4 },
		         new List<int> { 9, 2, 4, 15 }
    		};
    		
    		var testSets = testData.Select(s => new HashSet<int>(s));
    		
    		var groupedSets = testSets.GroupBy(s => s, HashSet<int>.CreateSetComparer());
    		
    		foreach(var g in groupedSets)
    		{
    			var setString = String.Join(", ", g.Key);
    			Console.WriteLine($" {g.Count()} | {setString}");
    		}
    	}
    }
