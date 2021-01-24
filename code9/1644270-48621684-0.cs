    [HttpGet]
    public async Task<IActionResult> ResetPassword(string UserId, string token)
    {
        ...
        
        ApplicationUser user = //get user;
        if(!await this._userManager.VerifyUserTokenAsync(user,this._userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token)){
            ViewBag.Message = this._localizer["tokenNotValid"].Value;
        }
            
        ...
    }
