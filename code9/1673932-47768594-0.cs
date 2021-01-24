    public class ApplicationSignInManager : SignInManager<ApplicationUser>
        {
            
            private readonly ILogger _logger;
            public ApplicationSignInManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
                ILogger<ApplicationSignInManager> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
            {
                _logger = logger;
            }
    
            public override async Task<SignInResult> PasswordSignInAsync(string userEmail, string password, bool isPersistent, bool shouldLockout)
            {
                if (UserManager == null)
                    return SignInResult.Failed;
                var result = await new FindUserCommand(_logger, UserManager, userEmail, password, shouldLockout).Execute();
    
                if (result != SignInResult.TwoFactorRequired) return result;
                var user = await UserManager.FindByEmailAsync(userEmail);
                return await SignInOrTwoFactorAsync(user, true);   // Required sets the session Cookie
            }
        }
