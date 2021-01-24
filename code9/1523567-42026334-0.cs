    public static class JsonExtensions
    {
        public static IEnumerable<T> DeserializeObjects<T>(Stream stream, JsonSerializerSettings settings = null)
        {
            var reader = new StreamReader(stream); // Caller should dispose
            return DeserializeObjects<T>(reader, settings);
        }
        public static IEnumerable<T> DeserializeObjects<T>(TextReader textReader, JsonSerializerSettings settings = null)
        {
            var ser = JsonSerializer.CreateDefault(settings);
            var reader = new JsonTextReader(textReader); // Caller should dispose
            reader.SupportMultipleContent = true;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.None || reader.TokenType == JsonToken.Undefined || reader.TokenType == JsonToken.Comment)
                    continue;
                yield return ser.Deserialize<T>(reader);
            }
        }
    }
