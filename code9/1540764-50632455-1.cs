     public class ProductRepository : IProductRepository
    {
        private readonly SalesDbContext _db;
        public ProductRepository(SalesDbContext db)
        {
            _db = db;
        }
       
    }
