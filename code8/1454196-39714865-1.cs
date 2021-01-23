    public class CommonController : Controller
    {
    	[AllowAnonymous]
    	public ActionResult PageNotFound()
    	{
    		Response.StatusCode = 404;
    		Response.TrySkipIisCustomErrors = true;
    
    		return View();
    	}
    }
