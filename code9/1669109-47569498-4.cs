    public class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Response);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Response originalResponse = (Response)value;
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(originalResponse.Status));
            writer.WriteValue(originalResponse.Status);
            writer.WritePropertyName(nameof(originalResponse.Series));
            writer.WriteStartArray();            
            foreach (var val in originalResponse.Series)
            {
                writer.WriteStartArray();
                writer.WriteValue(val.ColorCode);
                writer.WriteValue(val.ColorVal);
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
