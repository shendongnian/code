        public async void LogOn(IUser user, string domain, bool remember, TimeSpan timeout)
        {
			var context = AccessorsHelper.HttpContextAccessor.HttpContext;
			await context.SignOutAsync(IdentityConstants.ApplicationScheme);
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.GetId().ToString())
			};
			claims.AddRange(user.GetRoles().Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
			await context.SignInAsync(IdentityConstants.ApplicationScheme,
				new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthenticationType")), // AuthenticationType is just a text and I do not know what is its usage.
				new AuthenticationProperties
				{
					IsPersistent = remember,
					ExpiresUtc = DateTimeOffset.UtcNow.Add(timeout)
				});
		}
