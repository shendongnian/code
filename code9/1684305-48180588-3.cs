    public class FloatParseHandlingConverter : JsonConverter
    {
        readonly FloatParseHandling floatParseHandling;
        public FloatParseHandlingConverter(FloatParseHandling floatParseHandling)
        {
            this.floatParseHandling = floatParseHandling;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var old = reader.FloatParseHandling;
            try
            {
                reader.FloatParseHandling = floatParseHandling;
                existingValue = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
                serializer.Populate(reader, existingValue);
                return existingValue;
            }
            finally
            {
                reader.FloatParseHandling = old;
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
