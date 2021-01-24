    public class HomeController : Controller
    {
        public class eventsClass {
            public IList<YouWillGetThisFromDB> events = new List<YouWillGetThisFromDB>();
        }
        public class YouWillGetThisFromDB
        {
            public string id { get; set; }
            public string title {get; set;}
            public string start {get; set;}
            public bool allDay {get; set;}
        }
        public JsonResult GetCalendarEvents()
        {
            YouWillGetThisFromDB you = new YouWillGetThisFromDB
            {
                id = "theId",
                title = "theTitle",
                start = "1/5/2017",
                allDay = true
            };
            eventsClass ec = new eventsClass();
            ec.events.Add(you);
            return Json(ec.events, JsonRequestBehavior.AllowGet); 
        }
        public ActionResult Index15()
        {
            return View();
        }
