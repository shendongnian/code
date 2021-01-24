        public class MyClaimsPrincipalFactory<TUser>: UserClaimsPrincipalFactory<TUser> where TUser : ApplicationUser
        {
            public MyClaimsPrincipalFactory(
            UserManager<TUser> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, 
             optionsAccessor)
           {
     
            }
     
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(TUser user)
        {
            var id = await base.GenerateClaimsAsync(user);
            id.AddClaim(new Claim(MyClaimTypes.IsAdmin, user.IsAdministrator.ToString().ToLower()));
            return id;
        }
      }
