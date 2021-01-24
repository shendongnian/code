    public class MyController:Controller
    {
        public ActionResult Index()
        {
           ViewBag.ImagePath = //your service call
           return View();
        }
    }
