    codepublic class StoreController : Controller
    {
        private DefaultDbContext _dbContext = null;
        public StoreController(DefaultDbContext dbContext)
        {
            this._dbContext = dbContext;
            //Do something with this._dbContext ...
        }
    }
