    public class MoneyJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = (reader.Value ?? "").Replace(" ", "").Replace(",", ".");
            TypeConverter converter = TypeDescriptor.GetConverter(modelType);
            object result = converter.ConvertFromInvariantString(value);
            return result;;   
        }
    }
