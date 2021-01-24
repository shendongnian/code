    public class ProductImporter
    {
        private readonly IProductRepository _productRepository;    
    
        public ProductImporter(IProductRepository productRepository)
        {
            this.__productRepository = this._productRepository;
        }
    
        public void AddProducts(IEnumerable<Product> products)
        {
            foreach(var product in products)
            {
                this._productRepository.Add(product);
            }
        }
        ...
    }
