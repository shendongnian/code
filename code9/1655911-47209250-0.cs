	var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
	ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
	if (user == null)
	{
		context.SetError("invalid_grant", "The user name or password is incorrect.");
		return;
	}
    // This if was required:
	if (!user.EmailConfirmed)
	{
		context.SetError("email_not_confirmed", "You did not confirm your email.");
		return;
	}
	ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
	   OAuthDefaults.AuthenticationType);
	ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
		CookieAuthenticationDefaults.AuthenticationType);
	AuthenticationProperties properties = CreateProperties(user.UserName);
	AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
	context.Validated(ticket);
	context.Request.Context.Authentication.SignIn(cookiesIdentity);
}
