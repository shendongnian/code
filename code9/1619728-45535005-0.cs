    public class ProductReader
    {
        private readonly string path;
        public ProductReader(string path) {
            this.path = path;
        }
        public List<ProductItem> GetAllProductsFromCSV() { ... }
    }
