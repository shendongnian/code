    class ConstructFromStringConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ConstructorInfo ctor = objectType.GetConstructor(new Type[] { typeof(string) });
            if (ctor != null)
            {
                return ctor.Invoke(new object[] { (string)reader.Value });
            }
            throw new JsonException(objectType.Name + " does not have a public constructor that accepts a string.");
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
