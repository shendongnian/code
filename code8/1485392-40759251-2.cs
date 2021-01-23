    public class UntypedListJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                return serializer.Deserialize(reader);
            }
    
            return serializer.Deserialize<List<object>>(reader);
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object);
        }
    }
