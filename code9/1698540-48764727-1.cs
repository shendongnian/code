    void Main()
    {
    	var dictionaryList = JsonConvert.DeserializeObject<Response>(@"{
    			""Resources"": [
    		      {
    	      ""Key"": ""HeadingCustomerSegments"",
    		        ""Value"": ""Customer segments""
    	    },
    	    {
    		""Key"": ""Clear all"",
    	      ""Value"": ""Clear all""
    	
    		},
    	    {
    		""Key"": ""Third selection of stores the report will be based on"",
    	      ""Value"": ""Third selection of stores the report will be based on""
    	
    		},
    	    {
    		""Key"": ""Select the stores to be included in the Dashboard/Opportunity"",
    	      ""Value"": ""Select the stores to be included in the Dashboard/Opportunity""
    	
    		}]
    	}");
    
    	var value = dictionaryList.Resources.Where(r => r.Key == "HeadingCustomerSegments").Select(r => r.Value).FirstOrDefault();
    	Console.WriteLine(value);
    }
    
    public class Response
    {
    	public List<Resource> Resources { get; set; }
    }
    
    public class Resource
    {
    	public string Key { get; set; }
    	public string Value { get; set; }
    }
