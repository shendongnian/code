    class MyJsonConverter : JsonConverter
    {
        private readonly JsonSerializer _serializer;
        public MyJsonConverter(JsonSerializer serializer)
        {
            _serializer = serializer;
        }
        public override void WriteJson(JsonWriter writer, object value)
        {
            var context = _serializer.Context;
            ...
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue)
        {
            var context = _serializer.Context;
            ...
        }
        public override bool CanConvert(Type objectType)
        {
            ...
        }
    }
