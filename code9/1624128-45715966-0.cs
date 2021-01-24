    public class OrderStatusData
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string Buy { get; set; }
    }
    public class MainData
    {
        public string H { get; set; }
        public string M { get; set; }
        public OrderStatusData[] A { get; set; }
    }
