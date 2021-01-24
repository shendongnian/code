    public class Root
    {
        [JsonConverter(typeof(TestIgnoreEmptyListConverter))]
        public Test test { get; set; }
    }
    // .................
    public class TestIgnoreEmptyListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Test).IsAssignableFrom(objectType) || objectType.IsArray;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token is JArray)
                return default(Test);
            else
                return token.ToObject<Test>();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
