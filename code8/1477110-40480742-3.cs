    [JsonConverter(typeof(StringIdConverter))]
    class StringId
    {
        public string Value { get; set; }
    }
    class StringIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(StringId);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            return new StringId { Value = (string)token };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var id = (StringId)value;
            writer.WriteValue(id.Value);
        }
    }
