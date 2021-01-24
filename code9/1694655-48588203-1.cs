    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> PasswordReset(string token)
    {
            //Other codes
    
        var vm = new PasswordResetViewModel();
        vm.Token = token;
        return View("ForgotPassword", vm);
   }
