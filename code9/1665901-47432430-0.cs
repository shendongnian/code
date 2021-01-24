    public class CodeSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var code = value as Code;
            writer.WriteValue(code.code);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Code).IsAssignableFrom(objectType);
        }
    }
