    public class HomeController : BaseController
    {       
        public ActionResult Index()
        {
            var classItem1 = Variables.actvStat;
            var item1 = actvStat;
            return View();
        }
    }
