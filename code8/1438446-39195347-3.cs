    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"{
    						   ""id"":1,
    						   ""phone"":""415-000-1234"",
    						   ""name"":"" "",
    						   ""email"":null,
    						   ""address"":null,
    						   ""assignee"":null,
    						   ""notes"":[
    						
    						   ],
    						   ""created_at"":null,
    						   ""items"":{
    							  ""0"":{
    								 ""minimized"":false,
    								 ""sku"":{
    									""partner_id"":21,
    									""type_id"":44,
    									""errors"":{
    						
    									}
    								 }
    								}
    							}
    						}";
    		
    		
    		Console.WriteLine("Deserializing json...");
    		RootObject o = JsonConvert.DeserializeObject<RootObject>(json, new JsonSerializerSettings
    		{
    			MissingMemberHandling = MissingMemberHandling.Ignore,
    			NullValueHandling = NullValueHandling.Ignore
    		});		
    		Console.WriteLine("Success!");
    		Console.WriteLine("id #: {0}",o.id);
    		Console.WriteLine("phone #: {0}",o.phone);
    		foreach (var item in o.items)
    		{			
    			Console.WriteLine("  Item #: {0}",item.Key);
    			if (item.Value != null)
    			{
    				Console.WriteLine("    SKU: partner_id: {0}",item.Value.sku.partner_id);	
    				Console.WriteLine("    SKU: type_id: {0}",item.Value.sku.type_id);	
    			}
    		}		
    	}
    }
