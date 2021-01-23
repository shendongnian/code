    public class SelectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Selection);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = new JObject(
                JArray.Load(reader)
                      .Children<JObject>()
                      .Select(jo => new JProperty((string)jo["name"], jo["value"]))
                );
            var selection = new Selection();
            serializer.Populate(obj.CreateReader(), selection);
            return selection;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
