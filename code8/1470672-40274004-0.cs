    public class InfoConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.TokenType == JsonToken.Boolean ? null : serializer.Deserialize(reader, objectType);
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
