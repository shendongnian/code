    public class ProductRepository
    {
        private readonly string _connectionString;
        public MyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Product> GetProducts()
        {
            using (var connection = new OleDbConnection(_connectionString))
            using (var command = new OleDbCommand("command text", connection))
            {
                connection.Open();
                //execute command and return results here
            }
        }
        public void AddProduct(Product product)
        {
            using (var connection = new OleDbConnection(_connectionString))
            using (var command = new OleDbCommand("command text", connection))
            {
                connection.Open();
                //execute command here
            }
        }
    }
