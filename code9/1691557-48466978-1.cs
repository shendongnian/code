    [Route("[controller]/[action]")]
    public class HomeController : Controller {
    
        [HttpGet]
        [Route("/")]
        [Route("/[controller]")]
        public IActionResult Index() {
            return View();
        }
    
        [HttpGet]
        public IActionResult Error() {
            return View();
        }
    }
