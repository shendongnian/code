    // GET
    public async Task<IActionResult> PasswordResetEmail(UserEmailViewModel model)
    {
        //Other codes
    
        var vm = new PasswordResetViewModel();
        vm.Token = token;
        return View("ForgotPassword", vm);
    }
