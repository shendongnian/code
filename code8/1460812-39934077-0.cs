    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl) {
    
        if (!ModelState.IsValid) {
            return View(model);
        }
    
        var identity = new  ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);
        identity.AddClaim(new Claim(ClaimTypes.Name, model.Email));
        identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
        identity.AddClaim(new Claim(ClaimTypes.Sid, "123"));
        AuthenticationManager.SignIn(new AuthenticationProperties {
            IsPersistent = model.RememberMe
        }, identity);
        return RedirectToLocal(returnUrl);
    }
