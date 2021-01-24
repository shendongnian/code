    using System.Web.Mvc;
    
    namespace WebApplication6.Controllers
    {
        public class PatientController : Controller
        {
            [HttpGet]
            public ActionResult Treatments(string recordid)
            {
                return View();
            }
        }
    }
