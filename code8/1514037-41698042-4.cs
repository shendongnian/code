    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> config;
        public HomeController(IOptions<MyConfig> config)
        {
            this.config = config;
        }
        
        public IActionResult Index()
        {
            var value = config.Value.ApplicationName;
            var vars = config.Value.Version;
            return View();
        }
    }
