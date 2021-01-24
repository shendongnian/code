    public static class JsonExtensions
    {
        public static T DeserializeEmbeddedJsonP<T>(Stream stream)
        {
            using (var textReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(textReader.SkipPast('(')))
            {
                var settings = new JsonSerializerSettings
                {
                    CheckAdditionalContent = false,
                };
                return JsonSerializer.CreateDefault(settings).Deserialize<T>(jsonReader);
            }
        }
    }
    public static class TextReaderExtensions
    {
        public static TTextReader SkipPast<TTextReader>(this TTextReader reader, char ch) where TTextReader : TextReader
        {
            while (true)
            {
                var c = reader.Read();
                if (c == -1 || c == ch)
                    return reader;
            }
        }
    }
