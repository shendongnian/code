    public LoginController : Controller
    {
        public ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            if(loginService==null)
                throw new ArgumentNullException(nameof(loginService));
            this.loginService = loginService
        }
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel login)
        {
            // Do your stuff from above
            ...
            bool success = await loginService.Login(login);
            ...
        }
    }
