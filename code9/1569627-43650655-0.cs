    public class HomeController : Controller
    {
        private readonly IService service;
        public HomeController(IService service)
        {
            this.service = service;
        }
        public ViewResult Index()
        {
            return View(new Model(this.service));
        }
    }
