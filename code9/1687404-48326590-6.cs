    public class HomeController : Controller
    {
        private readonly ISessionManager _sessionManager;
        public HomeController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public ActionResult Index()
        {
            if (!_sessionManager.IsUserLoggedIn || _sessionManager.CurrentUser.EmployeeId == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (_sessionManager.UserType == "ADMIN")
            {
                return View(); //we have to run this view than test will pass
            }
            else
                return HttpNotFound();
        }
    }
