    public class StoreController : Controller
    {
        public ActionResult Index(string viewName = "Index")
        {
            var model = new SomeViewModel();
            return View(viewName, model);
        }
    }
    public class SofiaStoreController : StoreController
    {
        public ActionResult GetIndex(string city)
        {
            return base.Index();
        }
    }
