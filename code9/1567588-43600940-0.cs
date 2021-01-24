	public class HomeController : Controller
	{
		public ActionResult Index20()
		{
			MyViewModel m = new MyViewModel();
			return View(m);
		}
