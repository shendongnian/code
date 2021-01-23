    public sealed class FloatStringConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(decimal);
        }
    }
