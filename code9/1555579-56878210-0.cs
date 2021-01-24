        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int outVal = 0;
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    outVal += (int)Enum.Parse(objectType, reader.Value.ToString());
                    reader.Read();
                }
            }
            return outVal;
        }
