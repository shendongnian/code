    public class HomeController : Controller
    {
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
        }
    }
