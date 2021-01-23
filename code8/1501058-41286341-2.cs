    namespace toolSwitchboard.Controllers
    {
        public class SwitchboardController : Controller
        {
            // GET: Switchboard
            public ActionResult Index()
            {
                ViewData["Message"] = "Your application description page for Switchboard.";
                ViewData["theYear"] = DateTime.Now.Year.ToString();
    
                getMainData();
    
                return View();
            }
    
        public ActionResult getMainData()
        {            
            if (UnboundNewClass == "NEW")
            {
                return RedirectToAction("Index", "AddPresenter"); //Will Redirect you to AddPresenterController.Index()
            }
            else
            {
                ViewBag.Admin = false;
                ViewBag.AddP = false;
                ViewBag.MyClasses = true;
                ViewBag.Change = true;
                ViewBag.New = false;
                ViewBag.BTT = false;
                ViewBag.Eval = false;
                ViewBag.cup = false;
                ViewBag.SCHEDULE = false;
                ViewBag.Travel = false;
    
                return View();
            }
        }
        
        }
    }
