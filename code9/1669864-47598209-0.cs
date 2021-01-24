    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    					
    public class Program
    {
    	static IEnumerable<int> Range(int min, int max)
    	{
    		for (int i = min; i <= max;i++) yield return i;
    	}
    	
    	
    	public static void Main()
    	{
    				
    		var firsts = new HashSet<int>();
    		
    		for(int i=0; i<10;i++)
    		{
    			var h = new HashSet<int>();
    		
    			foreach(var num in Range(-1000,+1000).OrderBy(o => Guid.NewGuid()).ToList()) 
    			{
    				h.Add(num);
    				
    				firsts.Add(h.First());
    			}
    			
    			Console.WriteLine("Run: " + i.ToString());
    			Console.WriteLine("# in h: " + h.Count().ToString());
    			Console.WriteLine("All firsts: " + string.Join(",",firsts));
    			firsts.Clear();
    
    		}
    		Console.ReadLine();
    	}
    }
