    public class SkiesController : Controller  
    {  
            // GET: Home  
            [HttpGet]  
            public ActionResult Index()  
            {  
                return View();  
            }  
            [HttpPost]  
            public JsonResult SearchSkies(string query)  
            {                
            SkiDao skiDao = new SkiDao();
            IList<Ski> skies = skiDao.SearchSkies(query);
            List<string> brands = (from Ski s in skies select s.Brand).ToList();
            return Json(brands, JsonRequestBehavior.AllowGet);
            }  
     } 
 
