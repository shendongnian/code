    public class HomeController : Controller {
        private IWebHostEnvironment _hostingEnvironment;
    
        public HomeController(IWebHostEnvironment environment) {
            _hostingEnvironment = environment;
        }
    
        [HttpGet]
        public IActionResult Get() {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "Sample.PNG");
            return View();
        }
    }
