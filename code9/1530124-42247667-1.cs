    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		var json = JsonConvert.SerializeObject(new[] {1,2,3,4,5});
    		
    		Console.WriteLine(json);
    		
    		JsonSerializer serializer = new JsonSerializer();
    
            using (StringWriter sw = new StringWriter())
     		using (JsonWriter writer = new JsonTextWriter(sw))
    		{
    			serializer.Serialize(writer, new[] {1,2,3,4,5});
    			
    			Console.WriteLine(sw);
    		}
    	}
    }
