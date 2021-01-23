    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult WakeUp(int id)
        {
            // id will be the id of the server.
            // Do your logic here.
    
           return View(); // Or whatever you want to return.
        }
    }
