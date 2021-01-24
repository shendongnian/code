    public class SomeClass
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _context;
        public SomeClass(UserManager<ApplicationUser> userManager,IHttpContextAccessor context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task DoSomethingWithUser() {
            var user = await _userManager.GetUserAsync(_context.HttpContext.User);
            // do stuff
        }
    }
