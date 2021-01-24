    protected readonly IHostingEnvironment HostingEnvironment;
    
    public TestController(IConfiguration configuration, IHostingEnvironment hostingEnv){
        this.Configuration = configuration;
        this.HostingEnvironment = hostingEnv;
    }
    [HttpGet]
    public IActionResult Test(){
        if(this.HostingEnvironment.IsDevelopment()){
            // Do something
        }
    
        return View();
    }
