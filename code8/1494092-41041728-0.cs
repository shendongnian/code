    internal class RawJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }
    
            public override bool CanRead
            {
                get { return false; }
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue((string)value);
            }
        }
    
    class myClass 
    {
    	[JsonConverter(typeof(RawJsonConverter))]
    	public string x;
    }
    void Main()
    {
    	var x = new Dictionary<string,object> 
    		{ 
    		["A"]=new myClass {x = "<!-- ?A.x -->"},
    		["B"]=new myClass {x = "<!-- ?B.x -->"} 
    		};
    	
    	
    	JsonConvert.SerializeObject(x).Dump();
    }
