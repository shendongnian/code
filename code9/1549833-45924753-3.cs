    public SomeController : Controller 
    {
        IDbService dbService;
    
        public SomeController(IDbService dbService)
        {
            this.dbService = dbService;
        }
    
        public IActionResult Index()
        {
            return View(dbService.SomeRepo.List());
        }
    }
