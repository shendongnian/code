    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        private readonly ApplicationRoleManager _roleManager;
        public ApplicationSignInManager(ApplicationUserManager userManager, 
            IAuthenticationManager authenticationManager,
            ApplicationRoleManager rolemanager)
                : base(userManager, authenticationManager)
        {
             //inject the role manager to the sign in manager
            _roleManager=rolemanager;
        }
        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            var ident= await user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
            // add your custom claims here
            var userRoles=user.Roles.Select(r=>r.RoleId);
            ident.AddClaims(_roleManager.Roles.Where(r => userRoles.Any(ur => ur == r.Id))
                .Select(r=>r.Claims).ToList()
                .Select(c => new Claim("RoleClaims", c.ToString())));
            return ident;
        }
    }
