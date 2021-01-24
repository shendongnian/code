    public class SqlServerProductRepository: IProductRepository
    {
        private readonly string _connectionString;
    
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public Product GetProductById(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                //QuerySingle is an extension method from Dapper
                return connection.QuerySingle<Product>("select Name, Description, Id from Products where Id = @Id", new {Id = id});
            }
        }
    
        public void UpdateProduct(Product product)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                //Execute is an extension method from Dapper
                connection.Execute("update Products set Name = @Name, Description = @Description where Id = @Id", product);
            }
        }
        public List<Product> GetAllProducts()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                //Query is an extension method from Dapper
                //You'd likely want to implement filters/paging etc in a real world app
                return connection.Query<Product>("select Name, Description, Id from Products").AsList();
            }
        }
    }
