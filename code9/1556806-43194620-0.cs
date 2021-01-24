    class ResolveListConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<T> list = new List<T>();
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                while (reader.Value != null)
                {
                    list.Add(Converter(reader.Value));
                    reader.Read();
                }
            }
            else if(reader.Value != null)
            {
                list.Add(Converter(reader.Value));
            }
            return list;
        }
        public T Converter(object obj) => (T)Convert.ChangeType(obj, typeof(T));
        public override bool CanConvert(Type objectType) => true;
    }
