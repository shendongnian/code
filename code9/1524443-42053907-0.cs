    public class Data
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Unit { get; set; }
        public int Precision { get; set; }
        [JsonPropertyAttribute("type")]
        [JsonConverter(typeof(DataTypeConverter))]
        public Type DataType { get; set; }
    }
    public class DataTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var value = token.Value<string>();
            if (value == "float")
            {
                return typeof (float);
            }
            return null;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
