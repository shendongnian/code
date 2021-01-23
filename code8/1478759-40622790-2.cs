    public class MyController : Controller
    {
        private readonly IAntiforgery _antiforgery;
        public AccountController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery; 
        }
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                await _antiforgery.ValidateRequestAsync(HttpContext);
            }
            // rest of action
        }
    }
