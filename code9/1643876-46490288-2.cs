    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("myseofriendlyurlslug")]
        public IActionResult Index()
        {
            return View();
        }
    }
