    public class LookupsController : Controller
    {
        // GET: administration/lookups/{name}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string name)
        {
            var viewModel = new LookupsIndexViewModel(name);
    
            return View("index", viewModel);
        }
    }
