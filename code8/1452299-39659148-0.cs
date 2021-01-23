    public class JsonPlainBaseModelCustomConverter<T> : CustomCreationConverter<T>
    {
        public override T Create(Type objectType)
        {
            return (T)DependencyResolver.Current.GetService(objectType);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
    
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
