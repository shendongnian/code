    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly CompanySettings _companySettings;
        public HomeController(ApplicationDbContext ctx, IOptions<CompanySettings> settings)
        {
            _ctx = ctx;
            _companySettings = settings.Value;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            
            // _ctx and _companySettings can be used here
            return View(model);
        }
    }
