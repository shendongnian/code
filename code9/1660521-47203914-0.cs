    public class LoginViewComponent : ViewComponent
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        public LoginViewComponent(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetModelAsync().ConfigureAwait(false);
            return View(model);
        }
        public Task<LoginModel> GetModelAsync()
        {
            return Task.FromResult(new LoginModel(_signInManager, _logger));
        }
    }
