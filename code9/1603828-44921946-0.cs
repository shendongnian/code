    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var dic = findAllAndEqFilter("name eq 20 and surname eq 50");
    		
    		Console.WriteLine("Test 1\r\n");
    		foreach(var kpv in dic)
    			Console.WriteLine(kpv.Key + "->" + kpv.Value);
    		
    		dic = findAllAndEqFilter("name eq 21 or surname eq 51");
    		
    		Console.WriteLine("\r\nTest 2\r\n");
    		foreach(var kpv in dic)
    			Console.WriteLine(kpv.Key + "->" + kpv.Value);
    
    		dic = findAllAndEqFilter("name eq 22");
    		
    		Console.WriteLine("\r\nTest 3\r\n");
    		foreach(var kpv in dic)
    			Console.WriteLine(kpv.Key + "->" + kpv.Value);
    		
    		dic = findAllAndEqFilter("name lt 22");
    		
    		Console.WriteLine("\r\nTest 4\r\n");
    		foreach(var kpv in dic)
    			Console.WriteLine(kpv.Key + "->" + kpv.Value);
    	}
    	
    	public static Dictionary<string, string> findAllAndEqFilter(string odataFilter)
    	{
    		Dictionary<string, string> ret = new Dictionary<string, string>(); 
    		
    		
    		string[] byAnd = Regex.Split(odataFilter, "( and )");			
    		
    		string key = ""; 		
    		
    		foreach(var andSplit in byAnd)
    			if(!Regex.IsMatch(andSplit, "( and )")) // remove the and		
    			{
    				string[] byEq = Regex.Split(andSplit, "( eq )");
    				foreach(var eqSplit in byEq)
    					if(!Regex.IsMatch(eqSplit, "\\s")) // if there is no space, we can assume we got a eq		
    						if(key == "")
    							key = eqSplit;
    						else 
    						{
    							ret.Add(key, eqSplit);
    							key = "";
    						}
    						
    			}
    		
    		
    		return ret;
    	}
    }
