    public class CustomSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            var properties = value.GetType().GetProperties();
            writer.WriteStartObject();
            foreach (var property in properties)
            {
                string propertyName = property.Name.Replace('.', '_');
                // just write new property name and value
                writer.WritePropertyName(propertyName);
                writer.WriteValue(property.GetValue(value, new object[] { }));
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            List<JProperty> properties = jsonObject.Properties().ToList();
            object instance = Activator.CreateInstance(objectType);
            PropertyInfo[] objectProperties = objectType.GetProperties();
            foreach (var objectProperty in objectProperties)
            {
                JProperty jsonProperty = properties.SingleOrDefault(prop => prop.Name == objectProperty.Name.Replace('_', '.'));
                if (jsonProperty != null)
                {
                    objectProperty.SetValue(instance, jsonProperty.Value.ToString(), new object[] { });
                }
            }
            return instance;
        }
        public override bool CanConvert(Type objectType)
        {
            return true; // your logic here
        }
    }
