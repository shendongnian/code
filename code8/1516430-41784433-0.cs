    public class StrictIntConverter : JsonConverter
    {
        readonly JsonSerializer defaultSerializer = new JsonSerializer();
        public override bool CanConvert(Type objectType) 
        {
            return objectType.IsIntegerType();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float: // Accepts numbers like 4.00
                case JsonToken.Null:
                    return defaultSerializer.Deserialize(reader, objectType);
                default:
                    throw new JsonSerializationException(string.Format("Token \"{0}\" of type {1} was not a JSON integer", reader.Value, reader.TokenType));
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class JsonExtensions
    {
        public static bool IsIntegerType(this Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            if (type == typeof(long)
                || type == typeof(ulong)
                || type == typeof(int)
                || type == typeof(uint)
                || type == typeof(short)
                || type == typeof(ushort)
                || type == typeof(byte)
                || type == typeof(sbyte)
                || type == typeof(System.Numerics.BigInteger))
                return true;
            return false;
        }        
    }
