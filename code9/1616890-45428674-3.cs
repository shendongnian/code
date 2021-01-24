    public class DPInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DPInfo);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            JProperty points = obj.Properties().FirstOrDefault(p => p.Name != "last");
            DPInfo info = new DPInfo
            {
                key = points.Name,   // remove this line if you don't need the key
                points = points.Value.ToObject<decimal[][]>(),
                last = (long)obj["last"]
            };
            return info;
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
