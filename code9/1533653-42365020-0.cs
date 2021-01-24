    public class Order
    {
        [XmlElement("OrderData")
        public OrderOrderData { get; set; }
    }
    public class OrderOrderData
    {
        [XmlElement("OfferOrder")
        public OrderOrderDataOfferOrder[] OfferOrder { get; set; }
    }
