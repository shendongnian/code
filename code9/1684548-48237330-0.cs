    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public override async Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            var userIdentity = await CreateUserIdentityAsync(user);
            // Clear any partial cookies from external or two factor partial sign ins
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            if (rememberBrowser)
            {
                var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(ConvertIdToString(user.Id));
                // Set AllowRefresh to true
                AuthenticationManager.SignIn(new AuthenticationProperties { AllowRefresh = true, IsPersistent = isPersistent }, userIdentity, rememberBrowserIdentity);
            }
            else
            {
                // Set AllowRefresh to true
                AuthenticationManager.SignIn(new AuthenticationProperties { AllowRefresh = true, IsPersistent = isPersistent }, userIdentity);
            }
        }
    }
