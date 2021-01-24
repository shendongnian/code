    public class EpisodesController : Controller
    {
        private readonly ITestDbContext dbContext;
    
        public EpisodesController(ITestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    
    	...
    }
