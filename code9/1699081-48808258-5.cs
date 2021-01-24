    public class HomeController : Controller
    {
        [Authorize(Roles = "TaskAdmin", Policy = "RecordOwner")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
