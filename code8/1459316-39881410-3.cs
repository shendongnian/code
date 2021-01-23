    public class YourRootObject
    {
        public List<List<int>> items { get; set; }
        public DateTime updated { get; set; }
        public List<string> columns { get; set; }
    }
    public class EpochToDatetimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var l = (long)reader.Value;
            return new DateTime(1970, 1, 1).AddMilliseconds(l).ToLocalTime();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
