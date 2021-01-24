    public class UserController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(DbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Update(UserProfileModel model)
        {
            await _userManager.AddProfileAsync(_dbContext, model);
            return View();
        }
    }
