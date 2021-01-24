    using System.Web.Mvc;
    
    namespace AudAPIApp.Controllers
    {
        [Authorize]
        public class DashboardController : Controller
        {
            public ActionResult Index()
            {
                GoogleAPI googleReport = new GoogleAPI();
                googleReport.GenerateReport();
                return View(googleReport);
                //New to MVC not sure if this is how to instantiate my class?
            }
        }
    }
