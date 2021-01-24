    public class AController : Controller {
    
       [Route("/B/ActionB/{param1:int}/{param2:int}")]
       public ActionResult ActionA(int param1, int param2) { 
             return Content("Whatever"); 
       } 
    }
