    public abstract class DelegatingConverterBase : JsonConverter
    {
        private readonly JsonConverter original;
        protected DelegatingConverterBase(JsonConverter original)
        {
            this.original = original;
        }
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer) =>
            original.WriteJson(writer, value, serializer);
        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            original.ReadJson(reader, objectType, existingValue, serializer);
        public override bool CanRead => original.CanRead;
        public override bool CanWrite => original.CanWrite;
        public override bool CanConvert(Type objectType) => original.CanConvert(objectType);
    }
