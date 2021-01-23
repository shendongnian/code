    public class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyModel);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            var json = JObject.Load(reader);
            JToken typeToken;
            JToken valueToken;
            if (json.TryGetValue("type", StringComparison.InvariantCultureIgnoreCase, out typeToken) &&
                json.TryGetValue("value", StringComparison.InvariantCultureIgnoreCase, out valueToken))
            {
                string type = typeToken.Value<string>().ToLowerInvariant();
                var model = new MyModel();
                model.Type = type;
                switch (type)
                {
                    case "float":
                        model.Value = valueToken.Value<float>();
                        break;
                    case "int":
                        model.Value = valueToken.Value<int>();
                        break;
                    case "string":
                        model.Value = valueToken.Value<string>();
                        break;
                    case "bytes":
                        string input = valueToken.Value<string>();
                        int count = input.Length / 8;
                        byte[] bytes = new byte[count];
                        for (int i = 0; i < count; ++i)
                        {
                            bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
                        }
                        model.Value = bytes;
                        break;
                    default:
                        throw new NotSupportedException("The specified type is not supported: " + type);
                }
                return model;
            }
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
