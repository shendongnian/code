        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string text = reader.Value.ToString();
                if (string.IsNullOrWhiteSpace(text))
                {
                    return null;
                }
                return text;
            }
            throw new Exception("Can only convert strings.");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not needed because this converter cannot write json");
        }
        public override bool CanWrite
        {
            get { return false; }
        }
    }
