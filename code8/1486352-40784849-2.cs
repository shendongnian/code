    public class HomeController : Controller
    {    
        [HttpGet]
        public ActionResult WakeUp(int id)
        {
           // Possibly some validation here?
           // Send the id to the manager.
           var manager = new WakeUpManager();
           manager.WakeUp(id);
    
           return View(); // Or whatever you want to return.
        }
    }
    public class WakeUpManager
    {
        public void WakeUp(int serverId)
        {
            // Wake the server up... or snooze... or whatever. :)
        }
    }
