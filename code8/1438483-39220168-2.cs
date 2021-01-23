         public class HomeController : Controller
         {
            [HttpGet("/")]
             public IActionResult Index() 
         	{
	        	return View();
    	    }
	
	        [HttpPost("/")]
            public IActionResult Index(FormClass model) 
	       {
		    return View(model);
     	   }
        }
