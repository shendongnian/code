     public class HomeController : Controller
     {
       public ActionResult Index()
       {
         ViewData["Message"] = "Welcome to ASP.NET MVC!";
         return View();
       }
       public ActionResult About()
       {
           return View();
       }
       [Authorize]
       public ActionResult AuthenticatedUsers()
       {
           return View();
       }
       [Authorize(Roles = "Admin, Super User")]
       public ActionResult AdministratorsOnly()
       {
           return View();
       }
       [Authorize(Users = "admin")]
       public ActionResult SpecificUserOnly()
       {
           return View();
       }
     }
