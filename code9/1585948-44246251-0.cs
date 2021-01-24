	public class ErrorController : Controller 
	{
		public IActionResult Index(string errorCode)
		{
			return View(errorCode);
		}
	}
