    [Route("api/[controller]")]
    public class TestController : Controller
    {
    	[NonAction]
    	public override void OnActionExecuting(ActionExecutingContext context)
    	{
    		var responseHeaders = (FrameResponseHeaders)HttpContext.Response.Headers;
    		responseHeaders.MakeCaseInsensitive();
    	}
    
    	// GET api/values
    	[HttpGet]
    	public string Get()
    	{
    		var responseHeaders = (FrameResponseHeaders)HttpContext.Response.Headers;
    		responseHeaders.AddCaseInsensitiveHeader("Set-Cookie", "Cookies1");
    		responseHeaders.AddCaseInsensitiveHeader("SET-COOKIE", "Cookies2");
    		return "Hello";
    	}
    }
