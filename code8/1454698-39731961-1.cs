    [JsonConverter(typeof(JsonValueListConverter))]
    public sealed class JsonValueList
    {
        public JsonValueList()
        {
            this.Values = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> Values { get; private set; }
    }
    class JsonValueListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonValueList).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jsonValue = (existingValue as JsonValueList ?? new JsonValueList());
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException("Invalid reader.TokenType " + reader.TokenType);
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.PropertyName:
                        {
                            var key = reader.Value.ToString();
                            if (!reader.Read())
                                throw new JsonSerializationException(string.Format("Missing value at path: {0}", reader.Path));
                            var value = serializer.Deserialize<string>(reader);
                            jsonValue.Values.Add(new KeyValuePair<string, string>(key, value));
                        }
                        break;
                    case JsonToken.EndObject:
                        return jsonValue;
                    default:
                        throw new JsonSerializationException(string.Format("Unknown token {0} at path: {1} ", reader.TokenType, reader.Path));
                }
            }
            throw new JsonSerializationException(string.Format("Unclosed object at path: {0}", reader.Path));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonValue = (JsonValueList)value;
            writer.WriteStartObject();
            foreach (var pair in jsonValue.Values)
            {
                writer.WritePropertyName(pair.Key);
                writer.WriteValue(pair.Value);
            }
            writer.WriteEndObject();
        }
    }
