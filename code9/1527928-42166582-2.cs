    public class ReplaceArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) {
            // check for Array, IList, etc.
            return objectType.IsCollection(); 
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            // ignore existingValue and just create a new collection
            return JsonSerializer.CreateDefault().Deserialize(reader, objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            JsonSerializer.CreateDefault().Serialize(writer, value);
        }
    }
