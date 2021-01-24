    AccountController: Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
    
        public AccountController(SignInManager<ApplicationUser> singInManager)
        {
            _signInManager = signInManager;
        }
    
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            ...
        }
        
    }
