    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public CustomUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }
        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Name", user.Name));
            for (int i = 0; i < user.Content.Count; i++)
            {
                string content = Newtonsoft.Json.JsonConvert.SerializeObject(user.Content[i]);
                identity.AddClaim(new Claim("Content", content));
            }
            return identity;
        }
    }
