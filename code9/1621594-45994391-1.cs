         public class ProfileService : ProfileService<ApplicationUser>
        {
            private readonly UserManager<ApplicationUser> userManager;
            private readonly IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory;
            //Accessing HTTPContext in ASP.net Core
            private readonly IHttpContextAccessor httpContextAccessor;
            public ProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IHttpContextAccessor httpContextAccessor) : base(userManager, claimsFactory)
            {
                this.userManager = userManager;
                this.claimsFactory = claimsFactory;
                this.httpContextAccessor = httpContextAccessor;
            }
            //
            public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
            {
                var sub = context.Subject.Claims.Where(c => c.Type == "sub").FirstOrDefault().Value;
                var user = await userManager.FindByIdAsync(sub);
                var principal = await claimsFactory.CreateAsync(user);
                context.IssuedClaims.AddRange(principal.Claims);
                context.IssuedClaims.Add(new Claim("Ip", GetRequestIp(httpContextAccessor.HttpContext)));
            }
            public override async Task IsActiveAsync(IsActiveContext context)
            {
                //Check existing sessions
                var sub = context.Subject.GetSubjectId();
                var user = await userManager.FindByIdAsync(sub);
                var isactive = user != null;
                context.IsActive = isactive;
    }
    }
