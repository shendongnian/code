        [Authorize]
        public class HomeController : Controller
        {
    
            private readonly IUserSession _userSession;
    
            public HomeController(IUserSession userSession)
            {
                _userSession = userSession;
            }
    
            // GET: Home
            public ActionResult Index()
            {
    
                ViewBag.EmailAddress = _userSession.Username;
                ViewBag.AccessToken = _userSession.BearerToken;
    
                return View();
            }
        }
     public interface IUserSession
        {
            string Username { get; }
            string BearerToken { get; }
        }
    public class UserSession : IUserSession
        {
    
            public string Username
            {
                get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name).Value; }
            }
    
            public string BearerToken
            {
                get { return ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("AcessToken").Value; }
            }
    
        }
