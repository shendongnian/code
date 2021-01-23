    using System.Web.Mvc;
    
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }
    
        [Route("ModalContent")]
        [ChildActionOnly]
        public ActionResult ModalContent()
        {
            return View();
        }
    }
