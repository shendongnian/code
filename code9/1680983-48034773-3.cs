    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {	 
    	
    	static IEnumerable<int> FirstNumbersFromSeed(int seed, int num)
    	{
    		var r = new Random(seed);
    		for (int i=0;i<num;i++)
    		    yield return r.Next(4);
    	}
    	
    	public static void Main()
    	{
    		
    		Dictionary<string,List<int>> dict = new Dictionary<string,List<int>>();
    		
    		int num = 5;
    		for (int i =0;i<2000; i++)
    		{
    			var key = string.Join(",",FirstNumbersFromSeed(i,num));
    			
    			if (dict.ContainsKey(key)) dict[key].Add(i);
     			else dict[key] = new List<int>(i);
     		}
    		
    		foreach(var kvp in dict.Where(d => d.Value.Count > 1))
    			Console.WriteLine(string.Join(", ",kvp.Key) + " same first " + num + " values for seed with ints: " + string.Join(",",kvp.Value));
    	}
    }
