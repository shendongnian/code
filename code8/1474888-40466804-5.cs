    public class StreamConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Stream).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var bytes = serializer.Deserialize<byte[]>(reader);
            return new MemoryStream(bytes);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stream = (Stream)value;
            var bytes = stream.ReadAllBytesAndReposition();
            serializer.Serialize(writer, bytes);
        }
    }
    public static class StreamExtensions
    {
        public static byte[] ReadAllBytesAndReposition(this Stream stream)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                var position = stream.CanSeek ? stream.Position : (long?)null;
                while ((count = stream.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                if (position != null)
                {
                    // Restore position
                    stream.Position = position.Value;
                }
                return ms.ToArray();
            }
        }
    }
