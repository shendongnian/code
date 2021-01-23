    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var data = @"{
    	'Property1': [{
    		'items': [{
    			'b': 1,
    			'Q': 'data'
    		}, {
    			'b': 2,
    			'Q': 'more data'
    		}],
    		'seconds_ago': 1
    	}]
    }";
    		Rootobject deserializedObject = JsonConvert.DeserializeObject<Rootobject>(data);
    		Console.WriteLine(deserializedObject.Property1[0].items[0].b);
    		Console.WriteLine(deserializedObject.Property1[0].items[0].Q);
    		Console.WriteLine(deserializedObject.Property1[0].items[1].b);
    		Console.WriteLine(deserializedObject.Property1[0].items[1].Q);
    		Console.WriteLine(deserializedObject.Property1[0].seconds_ago);
    	}
    }
    
    public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }
    
        public class Class1
        {
            public Item[] items { get; set; }
            public int seconds_ago { get; set; }
        }
    
        public class Item
        {
            public int b { get; set; }
            public string Q { get; set; }
        }
