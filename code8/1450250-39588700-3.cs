    public class CommonController : Controller
        {
            // Initialize with Default value
            public ActionResult Index(String id = "0")
            {
                //Call from PageController
                if (id == "1")
                {
                    //Do some stuff
                }
                //Do other stuff of CommonController 
                return View();
            }
     }
