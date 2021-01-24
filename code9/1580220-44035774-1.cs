    public class HomeController : Controller
    {
    	private readonly IAntiforgery _antiForgeryService;
     
    	public HomeController(IAntiforgery antiForgeryService)
    	{
    		_antiForgeryService = antiForgeryService;
    	}
     
    	public IActionResult GetToken()
    	{
    		var token = _antiForgeryService.GetTokens(HttpContext).RequestToken;
    		HttpContext.Response.Cookies.Append("XSRF-TOKEN", token, new CookieOptions { HttpOnly = false });
    		return new StatusCodeResult(StatusCodes.Status200OK);
    	}
    }
