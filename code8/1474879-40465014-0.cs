    public class StreamConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stream = (Stream)value;
            using (var sr = new BinaryReader(stream))
            {
                var buffer = sr.ReadBytes((int)stream.Length);
                writer.WriteValue(Convert.ToBase64String(buffer));
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = reader.ReadAsString();
            var stream = new MemoryStream();
            using (var sr = new BinaryWriter(stream))
            {
                sr.Write(Convert.FromBase64String(str));
            }
            return stream;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Stream).IsAssignableFrom(objectType);
        }
    }
