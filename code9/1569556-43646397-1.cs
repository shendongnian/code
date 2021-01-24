    public class HomeController : Controller
    {
        SessionHelper mysession = new SessionHelper();
    
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_Get(SessionParameters pars)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", routeValues: new SessionParameters());
    
            //checkURL();                        
    
            pageload();
    
            return View(pars);            
        }
     }
