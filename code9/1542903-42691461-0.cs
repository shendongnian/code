    jsonFormatter.SerializerSettings.Converters.Add(new FloatConverter());
    public class FloatConverter : JsonConverter
    {
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }
    
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
    
            var val = Convert.ToDouble(value);
            if (Double.IsNaN(val) || Double.IsInfinity(val))
            {
                writer.WriteNull();
                return;
            }
            if (value is float)
                writer.WriteValue((float)value);
            else
                writer.WriteValue((double)value);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
    
            var value = JValue.Load(reader);
            var val = Convert.ToDouble(value);
    
            if (objectType == typeof(Double))
            {
                if (Double.IsNaN(val) || Double.IsInfinity(val))
                    return (Double)0.00;
                else
                    return (Double)value;
            }
    
            if (objectType == typeof(float?))
                return (float?)value;
            else
                return (float)value;
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(float);
        }
    }
