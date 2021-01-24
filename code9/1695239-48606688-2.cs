    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
    public class Person
    {
        public int PersonId { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        public bool Married { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        public bool SalaryUnderHundredDollar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json =
                @"{ ""PersonId"": 1234, ""State"": ""Florida"", ""Gender"": ""Male"", ""Married"": 1, ""SalaryUnderHundredDollar"": 1 }";
            var jObject = JObject.Parse(json);
            var person = jObject.ToObject<Person>();
        }
    }
