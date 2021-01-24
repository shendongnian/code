    public class ApplicationSignInManager : SignInManager<ApplicationUser>
        {
            private readonly ILogger _logger;
            private readonly ConfigurationSettings _configurationSettings;
            public ApplicationSignInManager(ConfigurationSettings configurationSettings, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
                ILogger<ApplicationSignInManager> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
            {
                _configurationSettings = configurationSettings;
                _logger = logger;
            }
    
            public override async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
            {
                var user = await UserManager.FindByLoginAsync(loginProvider, providerKey);
                if (user == null)
                {
                    return SignInResult.Failed;
                }
           
                var error = await PreSignInCheck(user);
                if (error != null)
                {
                    return error;
                }
                
                if (!_configurationSettings.CanSupporterUse3RdPartyLogin && user.IsXenaSupporter)
                    return SignInResult.NotAllowed;
    
                return await SignInOrTwoFactorAsync(user, isPersistent, loginProvider, bypassTwoFactor);
            }
    }
