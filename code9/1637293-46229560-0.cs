    public static class OrderExtensions
    {
        public static string GetFormattedPrice(this Order order)
            => order.Price.ToString("C", new CultureInfo("en-US"));
        public static string GetFormattedTimestamp(this Order order)
            => order.Timestamp.ToString("MM/dd/yyyy H:mm");
    }
