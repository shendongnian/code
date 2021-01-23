    public class ContactController : Controller
    {
        // GET: Contact
        public JsonResult Index()
        {   
            return Json(new { value1: "Hello", value2: "world" }, JsonRequestBehavior.AllowGet);
            
        }
    }
