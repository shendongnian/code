    public class ProductRepository
    {
        private readonly string _connectionString;
    	
        public ProductRepository(string connectionString)
    	{
    	    _connectionString = connectionString;
    	}
    
        public Product GetProductById(string productId)
    	{
    	    using(var connection = new SqlConnection(_connectionString))
    		{
    		    // I'm going to use Dapper here because it's super handy
    			// https://github.com/StackExchange/Dapper
    			var product = connection.QueryOne<Product>(
                    @"select
                          Id,
                          Name,
                          Price
                      from
                          products
                      where
                          Id = @ProductId",
                    new { ProductId = productId });
    			return product;
    		}
    	}
    }
