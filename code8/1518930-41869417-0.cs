    public class HomeController : Controller
        {
    
            public ActionResult Index()
            {
                var p1 = new Patient { date = DateTime.Now };
                var p2 = new Patient { date = DateTime.Now.AddDays(1) };
                var listOfPatients = new List<Patient>();
                listOfPatients.Add(p1);
                listOfPatients.Add(p2);
                return View(listOfPatients);
            }
    
            public ActionResult Timeline(DateTime date)
            {
                return Content(date.ToString());
            }
    
        }
