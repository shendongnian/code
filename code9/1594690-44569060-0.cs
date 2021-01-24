    public class HomeController : Controller
      {
        string replDatabase = string.Empty;
        // GET: Home
        public ActionResult Index()
        {
          ReplDataModel Model = new ReplDataModel();
          return View(Model);
        }
    
        [HttpPost]
        public ActionResult GetReplDatabase(ReplDataModel model)
        {
          replDatabase = model.SelectedReplDatabase;
          return View(model);
        }
      }
