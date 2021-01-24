    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    readonly IHttpClientFactory _httpClientFactory;
    
    public IActionResult Index()
    {
        var client = _httpClientFactory.CreateClient();
        //....do your code
        return View();
    }
