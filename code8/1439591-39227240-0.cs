    [XmlRoot("order")]
    public class Order
    {
        [XmlElement("date")]
        public List<OrderDate> Dates { get; set; }
    }
