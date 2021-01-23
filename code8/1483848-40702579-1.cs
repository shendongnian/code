    public class Product
    {
        public int ID { get: set; }
        public ProductInfo ProductInfo { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    } 
    Product product = genericRepository.GetSingle<Product>(p => p.Cost > 3000, p.ProductInfo, p.Orders)
