    using System;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://jsonplaceholder.typicode.com/posts");
    		request.ContentType = "text/json";
    		request.Method = "POST";
    		request.Timeout = 200000;
    		
    		JObject asnInfo = JObject.Parse(@"{ title: 'foo', body: 'bar', userId: 1 }");
    		
    		JsonSerializer serializer = new JsonSerializer();
    		
    		using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    		{
    			using (var writer = new JsonTextWriter(streamWriter))
    			{
    				serializer.Serialize(writer, asnInfo);
    			}
    		}
    
    		var response = (HttpWebResponse)request.GetResponse();
    		
    		using (var streamReader = new StreamReader(response.GetResponseStream()))
    		{
    			var responseText = streamReader.ReadToEnd();
    			
    			Console.WriteLine(responseText);
    		}
    	}
    }
