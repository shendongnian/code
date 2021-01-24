    public class MyController : Controller {
        private readonly HttpContext _context;
        public ApprovalController(IHttpContextAccessor httpContextAccessor) {
            _context = httpContextAccessor.HttpContext;
        }
    }
