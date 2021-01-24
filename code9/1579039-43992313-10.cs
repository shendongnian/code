    public class HomeController : Controller {
        private IHostingEnvironment _hostingEnvironment;
    
        public HomeController(IHostingEnvironment environment) {
            _hostingEnvironment = environment;
        }
    
        [HttpGet]
        public IActionResult Get() {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "Sample.PNG");
            return View();
        }
    }
