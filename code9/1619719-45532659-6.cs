    public class ProductsCSV {
        private readonly IProductsCsvReader reader;
        public ProductsCSV(IProductsCsvReader reader) {
            this.reader = reader;
        }
        public List<ProductItem> GetAllProductsFromCSV() {
            var productFilePath = @"~/CSV/products.csv";
            var csvData = reader.ReadAllLines(productFilePath);
            var result = parseProducts(csvData);
            return result;
        }
        //This method could also eventually be extracted out into its own service
        private List<ProductItem> parseProducts(String[] csvData) {
            List<ProductItem> result = new List<ProductItem>();
            //The following parsing can be improved via a proper
            //3rd party csv library but that is out of scope
            //for this question.
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
