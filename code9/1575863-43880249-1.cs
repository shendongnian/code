    [Redirect]
    public class MyCustomController : AsyncController
    {
        public ActionResult Index()
        {                        
            return View();            
        }
    	public ActionResult Foo()
    	{
    		//It will redirect
    		return View();
    	}
    }
