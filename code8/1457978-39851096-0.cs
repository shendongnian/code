    public class TestController : Controller
    {
        public ActionResult TestAction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestAction(User user)
        {
            ModelState.Clear()
            return View();
        }
    }
