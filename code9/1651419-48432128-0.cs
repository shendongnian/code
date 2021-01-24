    public async Task ClaimsLogin() {
        // Claims identity creation here...
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
    
        await Task.FromResult(
            AuthenticationHttpContextExtensions.SignInAsync(
                this.httpContextAccessor.HttpContext,
                "NameOfYourCookieHere",
                userPrincipal,
                new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(2880),
                    IsPersistent = false,
                    AllowRefresh = false
                }));
    }
    
