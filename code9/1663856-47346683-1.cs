    public class UserController : Controller
    {
        private readonly ProfileService _profileService;
        public UserController(ProfileService profileService)
        {
            _profileService = profileService;
        }
        public async Task<IActionResult> Update(UserProfileModel model)
        {
            await _profileService.AddProfileAsync(model);
            return View();
        }
    }
    public class ProfileService
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfileService(DbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddProfileAsync(UserProfileModel model)
        {
            // do stuff
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }
    }
