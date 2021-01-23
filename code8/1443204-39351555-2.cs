    public class RateJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {   // name used in a previous answer
            return (objectType == typeof(VRate));
        }
        public override object ReadJson(JsonReader reader, Type objectType, 
                                    object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            decimal d = 0M;
            Decimal.TryParse(token.ToString(), out d);        
            return d;
        }
        public override void WriteJson(JsonWriter writer, object value,
                        JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
