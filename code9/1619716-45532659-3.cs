    public class ProductsCSV {
        private readonly IProductsCsvReader reader;
        public ProductsCSV (IProductsCsvReader reader) {
            this.reader = reader;
        }
        public List<ProductItem> GetAllProductsFromCSV() {
            var productFilePath = @"~/CSV/products.csv";
            String[] csvData = reader.ReadAllLines(productFilePath);
            List<ProductItem> result = new List<ProductItem>();
            foreach (string csvrow in csvData) {
                var fields = csvrow.Split(',');
                ProductItem prod = new ProductItem() {
                    ID = Convert.ToInt32(fields[0]),
                    Description = fields[1],
                    Item = fields[2][0],
                    Price = Convert.ToDecimal(fields[3]),
                    ImagePath = fields[4],
                    Barcode = fields[5]
                };
                result.Add(prod);
            }
            return result;
        }
    }
