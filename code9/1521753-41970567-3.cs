    public class TypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (typeof(System.Type).IsAssignableFrom(value.GetType()))
            {
                // here you decide how much information you really want to dump
                writer.WriteValue(value.GetType().FullName);
            }
            else 
            {
                JToken t = JToken.FromObject(value);
                t.WriteTo(writer);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(System.Type).IsAssignableFrom(objectType);
        }
    }
