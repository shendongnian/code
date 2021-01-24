    using System;
    using Newtonsoft.Json;
    
    namespace JsonDeserializationTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var chaptersAsJson = "[" +
    			                     "    [" +
    			                     "        2," +
    			                     "        1416420134.0," +
    			                     "        \"2\"," +
                                     "        \"546cdb2645b9efbff4582d51\"" +
    			                     "    ], " +
                                     "    [" +
    			                     "        1," +
                                     "        1411055241.0," +
    			                     "        null," +
    			                     "        \"541afe8945b9ef69885d3d74\"" +
    								 "    ], " +
    			                     "    [" +
                                     "        0," +
    			                     "        1414210972.0," +
    			                     "        \"0\"," +
                                     "        \"544b259c45b9efb061521235\"" +
                                     "    ]" +
                                     "]";
    			var chaptersAsTwoDObjectArray = JsonConvert.DeserializeObject<object[][]>(chaptersAsJson);
    
    			// Use the chapters array
    			foreach (object[] chapter in chaptersAsTwoDObjectArray)
    			{
    				// what do you want to do with the object array?
    				Console.WriteLine(String.Join(", ", chapter));
    			}
    
    			Console.WriteLine("Finished.");
    		}
    	}
    }
