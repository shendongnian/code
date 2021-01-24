    internal class CustomBase64Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {                
            return System.Text.Encoding.UTF8.GetString((Convert.FromBase64String((string)reader.Value)));
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {                
            writer.WriteValue(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes((string)value)));
        }           
    }
