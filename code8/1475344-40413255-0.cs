    using System;
    using System.Web.SessionState;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()		
    	{
    		//Part 1: Using percentage as Key
    		Dictionary<double, string> dictionary = new Dictionary<double, string>();
    
    		dictionary.Add(11.44, "Faxe");    		
    		//(...)    		
    		dictionary.Add(1.29, "Vordingborg");
    		
    		//Here is Komune
    		dictionary.Add(5.89, "Komune");
    		
    		if (dictionary.ContainsKey(5.89)){
    			Console.WriteLine(String.Format("Found: {0}!", dictionary[5.89]));
    		} else {
    			Console.WriteLine("Not Found!");
    		}
    		
    		//Part 2: Using the string as Key
    		Dictionary<string,double> dictionaryStringPercent = new Dictionary<string,double>();
    
    		dictionaryStringPercent.Add("Faxe",11.44);    				
    		//(...)    		
    		dictionaryStringPercent.Add("Vordingborg",1.0);
    		
    		//Here is Komune
    		dictionaryStringPercent.Add("Komune",5.89);
    		
    		if (dictionaryStringPercent.ContainsKey("Komune")){
    			Console.WriteLine(String.Format("Found: {0}!", dictionaryStringPercent["Komune"]));
    		} else {
    			Console.WriteLine("Not Found!");
    		}
    	}
    }
