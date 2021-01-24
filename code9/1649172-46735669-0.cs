    public class ContentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IContentType);
        }
        Type GetConcreteType(JObject obj)
        {
            if (obj.GetValue(nameof(ContentA.SomePropertyOfContentA), StringComparison.OrdinalIgnoreCase) != null)
                return typeof(ContentA);
            // Add other tests for other content types.
            // Return a default type or throw an exception if a unique type cannot be found.
			throw new JsonSerializationException("Cannot determine concrete type for IContentType");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader);
            var concreteType = GetConcreteType(obj);
            return obj.ToObject(concreteType, serializer);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
