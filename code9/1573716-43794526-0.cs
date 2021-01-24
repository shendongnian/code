    public class YearConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Year);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            int year = (int)obj["value"];
            var data = new Dictionary<string, Data>();
            foreach (var dataItem in obj.Children()
                .OfType<JProperty>()
                .Where(p => p.Name.StartsWith("item")))
            {
                data.Add(dataItem.Name, dataItem.Value.ToObject<Data>());
            }
            return new Year
            {
                Value = year,
                Data = data
            };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
