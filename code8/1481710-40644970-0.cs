    [JsonConverter(typeof(DateParseHandlingConverter), DateParseHandling.None)]
    class InputModel
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class DateParseHandlingConverter : JsonConverter
    {
        readonly DateParseHandling dateParseHandling;
        public DateParseHandlingConverter(DateParseHandling dateParseHandling)
        {
            this.dateParseHandling = dateParseHandling;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var old = reader.DateParseHandling;
            try
            {
                reader.DateParseHandling = dateParseHandling;
                existingValue = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
                serializer.Populate(reader, existingValue);
                return existingValue;
            }
            finally
            {
                reader.DateParseHandling = old;
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
