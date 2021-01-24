    using System.Web.Mvc;
    using WebApplication2.Models;
    namespace WebApplication2.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                Class1 class1 = new Class1();
                return View();
            }
        }
