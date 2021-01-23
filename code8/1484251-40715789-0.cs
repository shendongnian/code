    public class CustomerController : Controller 
    {
       public ActionResult Index() 
       {
           return View();
       }
    
       [HttpPost]
       public ActionResult GetUpdate()
       {
          return Json(new { success = true, newPar = 4 }, JsonRequestBehavior.AllowGet);
       }
    }
