    public class Order
    {
        [XmlElement("OrderData")
        public OrderOrderData OrderData { get; set; }
    }
    public class OrderOrderData
    {
        [XmlElement("OfferOrder")
        public OrderOrderDataOfferOrder[] OfferOrder { get; set; }
    }
