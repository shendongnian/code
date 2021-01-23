    public class TelemetryDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(telemetryData);
        }
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var property = (JProperty)obj.First;
            return new telemetryData {
                ts = property.Name,
                temp = property.Value.Value<double>()
            };
        }
        public override void WriteJson(JsonWriter writer,
           object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
