    class conv : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((CData)value).Etc);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception(); // didn't bother
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CData);
        }
    }
    class Wrap
    {
        public CData Test { get; set; }
    }
    class CData 
    {
        public string Etc { get; set; }
    }
