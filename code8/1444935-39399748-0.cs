    public class HomeController : Controller
    {
        private readonly IFOO _fooBll;
        public HomeController(IFOO fooBll){
        _fooBll=fooBll;
         }
        public ActionResult Index()
        {
            return View();
        }
    }
