    public class Content : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("/Content/{*catchall}")]
        public IActionResult Index(string catchall)
        {
            // catchall = 1/2/3/4/5.html    
            return View();
        }
    }
