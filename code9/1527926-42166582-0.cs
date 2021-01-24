    public class ReplaceArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            serializer.Serialize(writer, value);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;
            try {
                var ja = serializer.Deserialize<JArray>(reader);
                return ja.ToObject(objectType);
            }
            finally {
                serializer.ObjectCreationHandling = ObjectCreationHandling.Auto;
            }
        }
        public override bool CanConvert(Type objectType) => objectType.IsCollection(); // extension method to check for array, IList, etc
    }
