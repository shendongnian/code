    public class ArrayString : JsonConverter
    {
        private readonly char _delimiter;
        // UPDATE -- added default constructor, so that 
        // JsonConverter attribute can be specified without the 
        // delimiter parameter, in which case semicolon will be used
        public ArrayString() : this(';')
        {
        }
        
        public ArrayString(char delimiter)
        {
            _delimiter = delimiter;
        }
        public override bool CanRead => true;
        public override bool CanWrite => true;
        
        public override bool CanConvert(Type objectType)
        {
            return true; 
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                return null;
            }
            var stringValue = new StringBuilder();
            while (reader.Read() && reader.TokenType == JsonToken.String)
            {
                if (stringValue.Length > 0)
                {
                    stringValue.Append(_delimiter);
                }
                stringValue.Append((string)reader.Value);
            }
            return stringValue.ToString();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stringValue = value?.ToString();
    
            if (stringValue == null)
            {
                writer.WriteNull();
                return;
            }
            var arrayValue = stringValue.Split(_delimiter);
            writer.WriteStartArray();
            foreach (var item in arrayValue)
            {
                writer.WriteValue(item);
            }
            writer.WriteEndArray();
        }
    }
