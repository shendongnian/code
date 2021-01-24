    public class CharListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<char>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var bytes = serializer.Deserialize<byte[]>(reader);
            return bytes.ToCharListWithoutEncoding();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (ICollection<char>)value;
            var bytes = list.ToByteArrayWithoutEncoding();
            serializer.Serialize(writer, bytes);
        }
    }
