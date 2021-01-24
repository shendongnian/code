    public class OrderExpected
    {
        public string orderNo { get; set; }
        public string customerNo { get; set; }
        public List<OrderItem> items { get; set; }
    }
    [JsonConverter(typeof(OrderItemConverter))]
    public class OrderItem
    {
        public int itemId { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
    }
    public class OrderItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.Name.Equals("OrderItem");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array =  JArray.Load(reader);
            return new OrderItem { 
                itemId = array[0].ToObject<int>(),
                price = array[1].ToObject<decimal>(),
                quantity = array[2].ToObject<decimal>()
            }; 
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var orderItem = value as OrderItem;
            JArray arra = new JArray();
            arra.Add(orderItem.itemId);
            arra.Add(orderItem.price);
            arra.Add(orderItem.quantity);
            arra.WriteTo(writer);
        }
    }
