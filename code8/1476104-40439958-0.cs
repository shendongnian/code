    public class Order
    {
        public int Id { get; set; }
        [JsonConverter(typeof(ShippingMethodConverter))]
        public string ShippingMethod { get; set; }
    }
    public class ShippingMethodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented because can't write");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                JObject obj = JObject.Load(reader);
                if (obj["Code"] != null) 
                    return obj["Code"].ToString();
                else 
                    return serializer.Deserialize(reader, objectType);
            }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
