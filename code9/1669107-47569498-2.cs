    public class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Response);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Response originalResponse = (Response)value;
            var transformedResponse = new { originalResponse.Status, Series = originalResponse.Series.ToDictionary(s => s.ColorCode, s => s.ColorVal) };
            serializer.Serialize(writer, transformedResponse);
        }
    }
