    var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager);
    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
    authenticationManager.SignOut("ApplicationCookie");
    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, oAuthIdentity );
