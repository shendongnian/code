    using System;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var json = "{'response':{'garbage':0,'details':[{'id':'123456789'}]}}";
    		var obj = JObject.Parse(json);
    		var details = obj["response"]["details"];
    		
    		Console.WriteLine(details);
    	}
    }
