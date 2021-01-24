    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var data = new
    		{
    			order_id = "111",
    			isTrue = true,
    			rating = 3,
    			goods = 
    			new []
    			{
    				new
    				{
    					amount = 100,
    					count = 2
    				},
    				new
    				{
    					amount = 9001,
    					count = 1
    				}
    			}
    		};
    		
    		var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings() { Formatting = Formatting.Indented });
    		
    		Console.WriteLine(json);
    	}
    }
