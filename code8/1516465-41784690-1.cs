    public class StudentController : Controller
    {
        // GET: Student/Index
        public ActionResult Index()
        {
            return View(new StudentViewModel());
        }
        // GET: Student/Index
        [HttpPost]
        public ActionResult Index(string groep)
        {
            return View(new studentViewModel(groep));
        }
    }
