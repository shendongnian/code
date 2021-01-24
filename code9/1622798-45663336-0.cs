    class EnumerationConverter<T> : JsonConverter where T : Headspring.Enumeration<T, int>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int val = Convert.ToInt32(reader.Value);
            return Headspring.Enumeration<T, int>.FromValue(val);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumVal = (Headspring.Enumeration<T, int>)value;
            writer.WriteValue(enumVal.Value);
        }
    }
