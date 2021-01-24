    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		var json = "{\"One\": [{  \"ID\": 1,  \"name\": \"s\"},{  \"categoryID\": 2,  \"name\": \"c\"}],\"Two\": [{  \"ID\": 3,  \"name\": \"l\"}],\"Three\": [{  \"ID\": 8,  \"name\": \"s&P\"},{  \"ID\": 52,  \"name\": \"BB\"}]}";		
    		var deserialized = JsonConvert.DeserializeObject<Dictionary<string, List<Model>>>(json);
    	
    		Console.WriteLine(deserialized["One"][0].name);
    	
    		Console.WriteLine("Filter to starts with s");
    		var filtered = deserialized.SelectMany(item => item.Value).Where(innerItem => innerItem.name.StartsWith("s"));
    		foreach(var item in filtered){
    			Console.WriteLine(item.name);	
    		}
    		
    	}
    	
    	public class Model{
    		public int ID {get;set;}
    		public string name {get;set;}
    		public int categoryID {get;set;}
    	}
    }
