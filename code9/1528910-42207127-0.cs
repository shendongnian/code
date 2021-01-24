    public class ProductService
    {
        private IProductRepository repository;
        public ProductService (IProductRepository repository)
        {
            this.repository = repository;
        }
        public Product GetProductById(int productId)
        {
            if(productId <= 0)
                return null;
            var product = this.repository.GetProductById(productId);
            return product;
        }
    }
