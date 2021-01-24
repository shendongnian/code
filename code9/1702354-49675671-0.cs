    public class PersonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var person = value as PersonName;
            if (person == null)
            {
                return;
            }
            serializer.Serialize(writer, person.Name);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var constructorInfo = objectType.GetTypeInfo().GetConstructors(BindingFlags.Public | BindingFlags.Instance).Single();
            var parameterInfo = constructorInfo.GetParameters().Single();
            var parameterType = parameterInfo.ParameterType;
            var value = serializer.Deserialize(reader, parameterType);
            return Activator.CreateInstance(objectType, new[] { value });
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(PersonName).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
