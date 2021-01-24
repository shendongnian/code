    public class CategoryController : ODataController
    {
        private readonly YourDbContext _ctx;
        public CategoryController(YourDbContext ctx)
        {
            _ctx = ctx;
        }        
 
        [EnableQuery]
        public IQueryable<Category_Master> Get()
        {
           return _ctx.Category_Master;
        }
    }
