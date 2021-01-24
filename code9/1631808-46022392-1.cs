    [Route("api/MyLogin")]
    public class LoginController : Controller
    {
    	[HttpGet]
    	public IActionResult Callback()
    	{
    		return View();
    	}
    }
