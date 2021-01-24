    public class MyViewModel
    {
        public string Comments {get;set;}
    }
    public class TTHController : Controller
      {
        // GET: Text_To_Hex
        public ActionResult Index()
        {
          return View();
        }
    
        [HttpPost]
        public ActionResult MyAction(MyViewModel model)
        {
            //Do class stuff
            //The comments will already be bound to the model in your post.
            //Just redirect passing in the same model.
            return RedirectToAction("Index", model);
        }
