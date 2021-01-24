    public class RawConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new InvalidOperationException();
            }
            var value = (string)reader.Value;
            var obj = JsonConvert.DeserializeObject(value, objectType);
            return obj;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var str = JsonConvert.SerializeObject(value);
            writer.WriteValue(str);
        }
    }
