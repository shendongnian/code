            public class HomeController : Controller
            {
                SessionHelper mysession = new SessionHelper();
              
        
                [HttpGet]
                [ActionName("Index")]
                public ActionResult Index_Get(string Arrival, string Departure, string Rooms, string Persons, string Childrens,  )
                {
                    checkURL();
                    pageload();
                    ViewBag.Arrival = Arrival;
                    ViewBag.Departure = Departure;
                    ViewBag.Rooms = Rooms;
                    ViewBag.Persons = Persons;
                    ViewBag.Childrens = Childrens;
                    return View(mysession);
                }
        }
