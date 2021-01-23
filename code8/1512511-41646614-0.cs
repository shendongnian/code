    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        return View(new LoginViewModel());
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        ClaimsPrincipal userClaims = _userRepository.TryLogin(model);
        if (userClaims != null)
        {
            ...
        }
        return View(model);
    }
