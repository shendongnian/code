    public class OrderExpected
    {
        public string OrderNo { get; set; }
        public string CustomerNo { get; set; }
        [JsonConverter(typeof(OrderItemConverter))]
        public List<OrderItem> Items { get; set; }
    }
    public class OrderItemConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jArray = JArray.Load(reader);
            var result = new List<OrderItem>();
            foreach (var arrayItem in jArray)
            {
                var innerJArray = arrayItem as JArray;
                if(innerJArray?.Count != 3)
                    continue;
                result.Add(new OrderItem
                {
                    ItemId = (int) innerJArray[0],
                    Price = (decimal)innerJArray[1],
                    Quantity = (decimal)innerJArray[2]
                });
            }
            return result;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
