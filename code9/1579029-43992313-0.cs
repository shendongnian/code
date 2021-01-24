    public class HomeController : Controller {
        private IHostingEnvironment _hostingEnvironment;
    
        public HomeController(IHostingEnvironment environment) {
            _hostingEnvironment = environment;
        }
    
        [HttpPost]
        public IActionResult Get() {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "Sample.PNG");
            return View();
        }
    }
