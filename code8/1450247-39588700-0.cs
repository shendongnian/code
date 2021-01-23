    public class PageController
    {
        public ActionResult Index()
        {
            //Let 
            var controllerName = "Common"// logic to get Controller name (already have)
            var ViewName = "Index" // logic to get View name (already have)
    
            return RedirectToAction("Index", "Common", new { id = "1" }); 
    
        }
    
    }
