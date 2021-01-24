     public class HomeController : Controller
        {
            private readonly IHostingEnvironment _hostingEnvironment;
    
            public HomeController(IHostingEnvironment hostingEnvironment)
            {
                _hostingEnvironment = hostingEnvironment;
            }
    
            public ActionResult Index()
            {
 
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                   var   JSON = System.IO.File.ReadAllText( contentRootPath + "/companyInfo.json");
                return null; 
            }
        }
