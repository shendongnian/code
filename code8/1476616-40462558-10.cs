    public class HomeController : Controller
    {
        SampleContext context=new SampleContext();
    
        public HomeController()
        {
            ViewBag.CompanyProfile = context.Profile.FirstOrDefault();      
        }
        public ActionResult Index()
        {
            return View();
        }
    }
