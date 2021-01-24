    [Route("[controller]/{action:index}")]
    public class HomeController : Controller {
    
        [HttpGet]
        public IActionResult Index() {
            return View();
        }
    
        [HttpGet]
        public IActionResult Error() {
            return View();
        }
    }
