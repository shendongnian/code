    using System.Web.Mvc;
    
    namespace Dashboard.Controllers
    {
        public class ShinyController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.IFrameSrc = "Address to your shiny app";
                return View();
            }
    
        }
    }
