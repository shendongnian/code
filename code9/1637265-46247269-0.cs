    public class JsonDateTimeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(string));
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return reader.Value.ToString().DateTimeFormatter("dd-MMM-yyyy");
            }
    
            public override bool CanWrite
            {
                get { return false; }
            }
    
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                
            }
        }
