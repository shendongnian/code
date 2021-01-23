    public class DefaultController : Controller
    {
       // [HttpPost] /*Remove this to initial load of Index page with GET method*/
        public ActionResult Index()
        {
            dlayer dl = new dlayer();
            DataSet ds = new DataSet();
            ds=dl.getalldata();           
            return View(ds);
        }
        public ActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insert(Class1 cls)
        {
            dlayer dl = new dlayer();
            string A = dl.insert(cls);
   
         return RedirectToAction("Index"); //This line for redirecting to Index after Insert
        }
