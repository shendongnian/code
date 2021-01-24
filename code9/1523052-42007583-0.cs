	void Main()
	{
		var str = @"{
		    ""objects"": [
		        {
		            ""name"": ""obj1"",
		            ""state"": {
		                ""type"": 4,
		                ""childs"": [
		                    {
		                        ""state"": {
		                            ""type"": 5
		                        }
		                    }
		                ]
		            }
		        }
		    ]
		}";
		
		var obj = JObject.Parse(str);
		
		GetValidObjects(obj, new string[] { "4", "5" }); // Name list of valid objects
	}
