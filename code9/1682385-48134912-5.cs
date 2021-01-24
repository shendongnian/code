    public class Target
    {
        private List<Product> _products = new List<Product>();
        public IEnumerable<Product> Products { get { return _products; } }
        public Target(Source source)
        {
            foreach(var sourceProduct in source.Products)
            {
                var product = new Product()
                {
                    Id = sourceProduct.Id
                    
                };
                foreach(var propertyIndex in sourceProduct.PropertiesIndexes)
                {
                    product.PropertiesData.Add(source.Properties[propertyIndex]);
                }
                _products.Add(product);
            }
        }
    }
