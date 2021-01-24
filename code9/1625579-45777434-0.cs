    public class StrictIntConverter : StrictIntConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int) || objectType == typeof(int?);
        }
    }
    public abstract class StrictIntConverterBase : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Type type = (Nullable.GetUnderlyingType(objectType) ?? objectType);
            bool isNullable = (Nullable.GetUnderlyingType(objectType) != null);
            if (reader.TokenType == JsonToken.Null)
            {
                if (isNullable)
                    return null;
                throw new JsonSerializationException(string.Format("Null value for {0}", objectType));
            }
            else if (reader.TokenType == JsonToken.Float)
            {
                throw new JsonSerializationException(string.Format("Floating-point value {0} found for {1}.", reader.Value, type));
            }
            else
            {
                // Integer or string containing an integer
                if (reader.Value.GetType() == type)
                    return reader.Value;
                return JToken.Load(reader).ToObject(type);
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
