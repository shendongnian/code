    private readonly IHostingEnvironment _hostEnvironment;
        public IConfiguration Configuration;
        public IActionResult Index()
        {
            return View();
        }
        public ViewerController(IHostingEnvironment hostEnvironment, IConfiguration config)
        {
            _hostEnvironment = hostEnvironment;
            Configuration = config;
        }
