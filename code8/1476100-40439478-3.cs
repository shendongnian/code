    public class Order
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string ShippingMethod
        {
            get
            {
                return (string)TempShippingMethod?["Code"];
            }
        }
        [JsonProperty("ShippingMethod")]
        private JObject TempShippingMethod { set; get; }
    }
----
    var res = JsonConvert.DeserializeObject<Order>(json);
