    public class HomeController : Controller {
        private IPathProvider pathProvider;
    
        public HomeController(IPathProvider pathProvider) {
            this.pathProvider = pathProvider;
        }
    
        [HttpGet]
        public IActionResult Get() {
            var path = pathProvider.MapPath("Sample.PNG");
            return View();
        }
    }
