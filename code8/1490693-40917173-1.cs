    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Farmers = _context.Farmers.ToList()
            };
            return View(model);
        }
    }
