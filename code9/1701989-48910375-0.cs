    public class CustomConverter : JsonConverter
    {
        private readonly Type[] _types;
        public CustomConverter(params Type[] types)
        {
            _types = types;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var properties = value.GetType().GetProperties();
            writer.WriteStartObject();
            foreach (var property in properties)
            {
                // Write the property name
                writer.WritePropertyName(property.Name);
                // Get the property type name of the property
                serializer.Serialize(writer, property.PropertyType.Name);
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }
