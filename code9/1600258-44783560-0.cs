    public class JsonDecimalConverter : JsonConverter
    {
        private int decimals;
        public JsonDecimalConverter(int decimals = 2)
        {
            this.decimals = decimals;
        }
        public override bool CanConvert(Type objectType) => objectType == typeof(decimal);
        public override object ReadJson(JsonReader reader,
           Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer,
           object value, JsonSerializer serializer)
        {
            writer.WriteValue(Decimal.Round((decimal)value, decimals));
        }
    }
