    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    					
    public class Program
    {
    	public static void Main()
        {
    		var dictionary = new Dictionary<string, int> {
    			{"ConfigA", 1200},
    			{"ConfigB", 1500},
    			{"ConfigC", 800},
    			{"ConfigD", 2}
    		};
    		
    		var serializer = new JavaScriptSerializer();
    		Console.WriteLine(serializer.Serialize(dictionary));
        }
    }
