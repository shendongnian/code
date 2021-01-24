    [EnableQuery]
    public class ProductsController : Controller
    {        
        private readonly IProductDbContext _dbContext;
        public ProductsController(IProductDbContext dbContext)
        {
             _dbContext = dbContext;
        }        
        [HttpGet]
        public IQueryable<Product> Get()
        {
            return _dbContext.Products.AsQueryable();
        }
    }
