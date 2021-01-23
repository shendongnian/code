    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult()
        {
            return View(new MyForm());
        }
        [HttpPost]
        public ActionResult Index(MyForm form)
        {
            return View(form);
        }
    }
