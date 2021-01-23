    [SessionAuthAttribute] //Applied for whole Controller
     public class HomeController : Controller
     {
          [SessionAuthAttribute] //Applied for 1 function
          public ActionResult Index()
          {
               return View();
          }
    
          public ActionResult About()
          {
    
               return View();
          }
     }
