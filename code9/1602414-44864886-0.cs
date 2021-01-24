    [RoutePrefix("TestPrefix")]
    public class TestController : Controller
    {
        [Route("TestAction")]
        public ActionResult TestAction()
        {
            //.........
            return View();
        }
    }
