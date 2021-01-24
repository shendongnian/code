    public class ServicePropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetServicePropertyValueType() != null;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var valueType = objectType.GetServicePropertyValueType();
            var value = serializer.Deserialize(reader, valueType);
            // Use the parameterized constructor.
            return Activator.CreateInstance(objectType, value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var baseValue = (ServicePropertyBase)value;
            serializer.Serialize(writer, baseValue.GetValue());
        }
    }
    internal static class ServicePropertyExtensions
    {
        public static Type GetServicePropertyValueType(this Type objectType)
        {
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(ServiceProperty<>))
            {
                return objectType.GetGenericArguments()[0];
            }
            return null;
        }
    }
