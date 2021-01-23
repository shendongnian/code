    public class IPAddressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IPAddress).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Bytes)
            {
                var bytes = (byte[])token;
                return new IPAddress(bytes);
            }
            else
            {
                var s = (string)token;
                return IPAddress.Parse(s);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ip = (IPAddress)value;
            writer.WriteValue(ip.ToString());
        }
    }
