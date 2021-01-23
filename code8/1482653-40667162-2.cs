    public class DictionaryValueTypeConverter<TDictionary, TKey, TValue, TValueSerialized> : JsonConverter
        where TDictionary : class, IDictionary<TKey, TValue>, new()
        where TValueSerialized : TValue
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var surrogate = serializer.Deserialize<Dictionary<TKey, TValueSerialized>>(reader);
            if (surrogate == null)
                return null;
            var dictionary = existingValue as TDictionary ?? new TDictionary();
            foreach (var pair in surrogate)
                dictionary[pair.Key] = pair.Value;
            return dictionary;
        }
    }
