    // URL /B/ActionB?p1=5&p2=9
    public class BController : Controller {
        public ActionResult ActionB(int p1, int p2) { 
            return RedirectToAction("ActionA", "A", new { param1 = p1, param2 = p2 });
       } 
    }
    // URL /A/ActionA?param1=5&param2=9
    public class AController : Controller {
        public ActionResult ActionA(int param1, int param2) { 
            return Content("Whatever") ; 
       } 
    }
