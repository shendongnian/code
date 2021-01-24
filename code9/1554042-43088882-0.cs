    public class TestController : Controller
        {
            //
            // GET: /Test/
    
            [HttpGet]
            public ActionResult Test()
            {
                var model = new CurrentViewModel();
                return View("Test", model);
    
            }
    
            [HttpGet]
            public ActionResult Test2()
            {
                var model = new CurrentViewModel();
                return View("Test2", model);
    
            }
    
            [HttpPost]
            public ActionResult TestPost(CurrentViewModel model)
            {
                return RedirectToAction("Test2");
            }
        }
