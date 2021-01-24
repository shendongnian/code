    public class Store
    {
        private readonly Product product;
    
        public Store(Product product)
        {
            // Create a new Product instance that only this Store instance
            // knows about
            this.product = new Product { Name = product.Name };
        }
    }
