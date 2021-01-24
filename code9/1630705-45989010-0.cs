    public class KeyValuePropertyArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var pairs = serializer.Deserialize<List<KeyValuePair<string, JToken>>>(reader);
            var jObj = new JObject(pairs.Select(p => new JProperty(p.Key, p.Value)));
            existingValue = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            serializer.Populate(jObj.CreateReader(), existingValue);
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
