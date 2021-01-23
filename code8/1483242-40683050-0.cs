    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View(Guys.First());
        }
    static List<Guy> Guys = new List<Guy> { new Guy(1, "phd", "hi1"), new Guy(2,     "proff", "hi2!"), new Guy(3, "proff.asst.", "hi3") };
    [HttpPost]
    public ActionResult Create(Guy obj)
    {
        Guys.Add(obj);
        return RedirectToAction("Index", "Guys");
    }}
 
