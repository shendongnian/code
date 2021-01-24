    class PriceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof( decimal? );
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize( reader ) as Price?;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize( writer, (decimal)((Price)value));
        }
    }
