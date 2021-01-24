    namespace foo.Controllers
    {
        public class BarController : Controller
        {
            private IHostingEnvironment _env;
    
            public BarController(IHostingEnvironment env)
            {
                _env = env;
            }
    
            public IActionResult Index()
            {
                var text1 = "site.css";
                ViewData["textInfo"] = Path.Combine( _env.WebRootPath,"css" , text1); //becomes myapppath/wwwroot/css/site.css
                return View();
            }
        }
    }
