    public class Order
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string ShippingMethod
        {
            get
            {
                return TempShippingMethod?.Code + " " +TempShippingMethod?.Description;
            }
        }
        [JsonProperty("ShippingMethod")]
        private TempShippingMethod TempShippingMethod { set; get; }
    }
    public class TempShippingMethod
    {
        public string Code { set; get; }
        public string Description { set; get; }
    }
----
    var res = JsonConvert.DeserializeObject<Order>(json);
