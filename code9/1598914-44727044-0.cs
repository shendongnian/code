    using Newtonsoft.Json;
    
    namespace JsonDeserializationTest
    {
    	class Chapter
    	{
    		public int Property1 { get; set; }
    		public decimal Property2 { get; set; }
    		public string Property3 { get; set; }
    		public string Property4 { get; set; }
    	}
    
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var chaptersAsJson = "[{\"property1\": 2, \"property2\": 1416420134.0, \"property3\": \"2\", \"property4\": \"546cdb2645b9efbff4582d51\"}, {\"property1\": 1, \"property2\": 1411055241.0, \"property3\": null, \"property4\": \"541afe8945b9ef69885d3d74\"},{\"property1\": 0,\"property2\": 1414210972.0, \"property3\": \"0\", \"property4\": \"544b259c45b9efb061521235\"}]";
    			var chapters = JsonConvert.DeserializeObject<Chapter[]>(chaptersAsJson);
			    // Use the chapters array
    			Console.WriteLine("Finished.");
    		}
    	}
    }
