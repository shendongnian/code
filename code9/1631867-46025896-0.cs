    public class FooConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (!(token is JValue))
                throw new JsonSerializationException("Token was not a primitive");
            return new Foo { Something = (string)token };
        }
