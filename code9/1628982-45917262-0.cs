    using System;
    using Newtonsoft.Json;
					
    public class Program
    {
	    public static void Main()
	    {
		    string json =  "{\"Result\":{\"isLinked\":true,\"saleDateTime\":\"16/06/2017 14:20:20\",\"storeName\":\"UAT1 BRIGHTON LOC 4\"},\"Status\":{\"ActionType\":0,\"IsSuccess\":true,\"ActionString\":\"\"}}";
		    dynamic jsonObject = JsonConvert.DeserializeObject(json);
		
		    Console.WriteLine(jsonObject);
	    }
    }
