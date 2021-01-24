    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    
    public class Invoice
    {
    	[JsonProperty("order_id")]	
    	public string OrderId { get;set;}
    	
    	public List<Good> Goods { get;set;}
    }
    
    public class Good
    {
    	public int Amount { get;set;}
    	public int Count { get;set;}
    }
    
    public class Program
    {	
    	public static void Main()
    	{
    		var invoice = new Invoice()
    		{
    			OrderId = "111",
    			Goods = new List<Good>()
    			{
    				new Good()
    				{
    					Amount = 100,
    					Count = 2
    				}
    			}
    		};
    		
    		var json = JsonConvert.SerializeObject(invoice, new JsonSerializerSettings()
    		{
    			Formatting = Formatting.Indented,
    			ContractResolver = new CamelCasePropertyNamesContractResolver() 
    		});
    		
    		Console.WriteLine(json);
    	}
    }
