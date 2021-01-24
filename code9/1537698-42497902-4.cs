    public class HomeController : Controller
    {
        private readonly IMyQuery _myQuery;
        private readonly IMySecondQuery _mySecondQuery;
        public HomeController(IMyQuery myQuery, IMySecondQuery mySecondQuery)
        {
            _myQuery = myQuery;
            _mySecondQuery = mySecondQuery;
        }
        public ActionResult MyQuery()
        {
            return Json(_myQuery.GetName(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult MySecondQuery()
        {
            return Json(_mySecondQuery.GetSecondName(), JsonRequestBehavior.AllowGet);
        }
    }
