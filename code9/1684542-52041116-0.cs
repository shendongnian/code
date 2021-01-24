    public class FakeSignInManager : SignInManager<ApplicationUser>
    {
        public FakeSignInManager()
                : base(new Mock<FakeUserManager>().Object,
                     new Mock<IHttpContextAccessor>().Object,
                     new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
                     new Mock<IOptions<IdentityOptions>>().Object,
                     new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
                     new Mock<IAuthenticationSchemeProvider>().Object)
            { }        
    }
 
    public class FakeUserManager : UserManager<ApplicationUser>
        {
            public FakeUserManager()
                : base(new Mock<IUserStore<ApplicationUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<ApplicationUser>>().Object,
                  new IUserValidator<ApplicationUser>[0],
                  new IPasswordValidator<ApplicationUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<ApplicationUser>>>().Object)
            { }
    
            public override Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
            {
                return Task.FromResult(IdentityResult.Success);
            }
    
            public override Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
            {
                return Task.FromResult(IdentityResult.Success);
            }
    
            public override Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
            {
                return Task.FromResult(Guid.NewGuid().ToString());
            }
    
        }
 
