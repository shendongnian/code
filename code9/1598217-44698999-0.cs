    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyDTO);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var customSerializer = new JsonSerializer {
                TypeNameHandling = TypeNameHandling.Objects, 
                Binder = new CustomSerializationBinder()
            };
            return customSerializer.Deserialize(reader, objectType);
        }
    }
