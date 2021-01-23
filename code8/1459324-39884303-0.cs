    public abstract class JsonCreationConverter<T> : JsonConverter
    {        
        protected abstract T Create(Type objectType, JObject jObject);
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            JObject jObject = JObject.Load(reader);           
            T target = Create(objectType, jObject);
            
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override bool CanWrite
        {
            get { return false; }
        }
    }
