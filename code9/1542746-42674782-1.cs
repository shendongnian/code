    public class OrderCreateGroup
    {
        public OrderCreateGroup()
        {
           ProductWithPrices = new List<ProductWithPrice>();
        }
        public Order Order { get; set; }
        public ICollection<ProductWithPrice> ProductWithPrices { get; set; }
    }
