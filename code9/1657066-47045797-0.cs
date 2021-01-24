    public class MyRequestConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyRequest);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string type = (string)jo["type"];
            MyRequest req = new MyRequest
            {
                Type = type,
                Source = (string)jo[type ?? ""]
            };
            return req;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MyRequest req = (MyRequest)value;
            JObject jo = new JObject(
                new JProperty("type", req.Type),
                new JProperty(req.Type, req.Source));
            jo.WriteTo(writer);
        }
    }
