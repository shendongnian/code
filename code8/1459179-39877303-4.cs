    public class PostController : Controller
    {
        
        public ActionResult ReadPost(string postName)
        {
            return View("~/views/home/Index.cshtml");
        }
        public ActionResult Comments(string postName)
        {
            ViewBag.Message = "Your application description page.";
            return View("~/views/home/Index.cshtml");
        }
        public ActionResult Edit(string postName)
        {
            ViewBag.Message = "Your contact page.";
            return View("~/views/home/Index.cshtml");
        }
        public ActionResult Author(string postName)
        {
            ViewBag.Message = "Your contact page.";
            return View("~/views/home/Index.cshtml");
        }
    }
