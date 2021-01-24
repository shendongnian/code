    using System.Web.Script.Serialization;
    using System.IO;
    
    public string mymethod()
    {
    
    	using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    	{
         		var result = streamReader.ReadToEnd();
    			
    		using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(result)))  
    		{  
       			// Deserialization from JSON  
       			DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(myresultclass));  
       		myresultclass obj = (myresultclass)deserializer.ReadObject(ms);  
       
    		}
    		
         		Console.WriteLine(result);
    
    		Console.WriteLine(myresultclass.request_id);
    	}
    }
