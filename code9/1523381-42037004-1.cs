     public class HomeController : Controller
        {
            ....
    
            [HttpPost]
            public ActionResult Index(StudentModel stu)
            {            
                if (ModelState.IsValid)
                {
                    //db operations
                    return RedirectToAction("Index");
                }
                return View(stu);
            }
            public ActionResult Subjects(int count)
            {
                ViewBag.count = count;
                return PartialView("SubjectPV");
            }
