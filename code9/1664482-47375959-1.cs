    public class TestBaseController : BaseController
    {
        public static IConfigurationRoot Configuration { get; set; }
        public TestBaseController(IConfiguration config,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<ManageController> logger) : base(config,userManager,signInManager,emailSender,logger)
        {
        }
        public string TestConfigGetter()
        {
            
            var t = Config["ConnectionStrings:DefaultConnection"];
            return t;
        }
        public class TestViewModel
        {
            public string ConnString { get; set; }
        }
        public IActionResult Index()
        {
            var tm = new TestViewModel { ConnString = TestConfigGetter() };
            return View(tm);
        }
    }
