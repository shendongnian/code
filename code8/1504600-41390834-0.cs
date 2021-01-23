    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"{
    					  'data': {
    						'4': {
    						  'id': '12',
    						  'email': 'lachlan12@somedomain.com',
    						  'first_name': 'lachlan'
    						  },
    						'5': {
    						  'id': '15',
    						  'email': 'appuswamy15email@somedomain.com',
    						  'first_name': 'appuswamy'
    						  }
    					   }
    					}";
    		
    		var data = JsonConvert.DeserializeObject<RootObject>(json);
    		Console.WriteLine("# of items deserialized : {0}", data.DataItems.Count);
    		foreach ( var item in data.DataItems)
    		{
    			Console.WriteLine("  Item Key {0}: ", item.Key);
    			Console.WriteLine("    id: {0}", item.Value.id);
    			Console.WriteLine("    email: {0}", item.Value.email);
    			Console.WriteLine("    first_name: {0}", item.Value.first_name);
    		}
    	}
    }
    
    public class RootObject
    {
    	[JsonProperty(PropertyName = "data")]
    	public Dictionary<string,DataItem> DataItems { get; set; }
    }
    
    public class DataItem
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
    }
