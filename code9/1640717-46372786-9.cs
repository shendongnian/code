    class IntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int) || objectType == typeof(int?);
        }
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.Integer:
                    // Input was already an integer.  Return it
                    return (int)JToken.Load(reader);
                case JsonToken.String:
                    {
                        int num;
                        if (Int32.TryParse(reader.Value.ToString(), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out num))
                            return num;
                        else
                            return 0;
                    }
                default:
                    throw new JsonSerializationException(string.Format("Unexpected token {0} at path {1}", reader.TokenType, reader.Path));
            }
        }
        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            // Int32 implements the IConvertible interface which has a ToString() overload
            // that takes an IFormatProvider specification.  Pass the invariant format to guarantee
            // identical serialization in all cultures.
            var convertible = (IConvertible)value;
            serializer.Serialize(writer, convertible.ToString(NumberFormatInfo.InvariantInfo));
        }
    }
