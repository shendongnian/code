    public class MyController : Controller {
         [Authorize(Roles="Admin")]
         public ActionResult AdminIndex() {
              return View();
         }
            
       
    
        [Authorize(Roles = "basic")]
        public ActionResult BasicUsersIndex() {
             return View();
        }
    }
