    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult StudentSearch()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult StudentSearch(SearchModel model)
        {
            if (ModelState.IsValid)
            {
            }
            return View(model);
        }
    }
