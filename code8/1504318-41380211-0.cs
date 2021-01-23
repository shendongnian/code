    public class Order
    {
        public List<Product> Products { get; set; }
    
        public Order() {
            this.Products = new List<Product>();
        }
    }
