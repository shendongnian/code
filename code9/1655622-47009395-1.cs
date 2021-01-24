     private readonly ILogger _logger;
     public HomeController(ILoggerFactory loggerFactory)
     {
         _logger = loggerFactory.CreateLogger<HomeController>();
     }
    
     public IActionResult Index()
     {
        _logger.LogInformation("Log information");
        _logger.LogError("Logger error");
        return View();
     }
