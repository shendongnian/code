    namespace Area_Model.Areas.admin.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /admin/Home/
            public ActionResult Index()
            {
                using (EF_Sample db = new EF_Sample())
                {
                    var sampleList = db.Students.ToList();
                }
                return View();
            }
    	}
    }
