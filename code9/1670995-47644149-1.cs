    private IDatabaseService ds;
    private IConfiguration Configuration { get; set; }
    
    public HomeController(IConfiguration configuration, IDatabaseService ds) {
        this.ds = ds;
        Configuration = configuration;
    }
    
    public IActionResult Index() {
        var diUsers = ds.GetUsers();
    
        var svm = SettingsViewModel();
    
        return View(svm);
    }
