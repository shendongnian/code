    using LinqToTwitter;
    using System.Web.Mvc;
    namespace MvcDemo.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                if (!new SessionStateCredentialStore().HasAllCredentials())
                    return RedirectToAction("Index", "OAuth");
                return View();
            }
        }
    }
