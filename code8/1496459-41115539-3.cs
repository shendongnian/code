    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
            ViewBag.Year = id;
            return View();
        }
        public ActionResult GetNewParameter(string Year)
        {
            string getId = Year;
            dynamic model = new ExpandoObject();
            model.getId = getId;
            return PartialView(model);
        }
    }
