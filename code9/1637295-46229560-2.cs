    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        
        // Original: decimal; Converted: string;
        public dynamic Price { get; set; }
        public string ShipperState { get; set; }
        // Original: DateTime; Converted: string;
        public dynamic Timestamp { get; set; }
    }
    public static class OrderExtensions
    {
        public static void Transform(this Order order)
        {
            if (order.Price.GetType() == typeof(decimal))
                order.Price = order.Price.ToString("C", new CultureInfo("en-US"));
            if (order.Timestamp.GetType() == typeof(DateTime))
                order.Timestamp = order.Timestamp.ToString("MM/dd/yyyy H:mm");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var originalList = new List<Order>()
            {
                new Order() { Id = 1, OrderNumber = "1", Price = 100m, Timestamp = DateTime.Now },
                new Order() { Id = 2, OrderNumber = "2", Price = 200m, Timestamp = DateTime.Now },
                new Order() { Id = 3, OrderNumber = "3", Price = 300m, Timestamp = DateTime.Now }
            };
            originalList.ForEach(order => order.Transform());
        }
    }
