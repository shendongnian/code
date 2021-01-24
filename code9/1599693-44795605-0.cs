    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            var user = _userManager.GetUserAsync(context.Subject).Result;
            var claims = new List<Claim>
            {
                new Claim("FullName", user.FullName),
			};
            context.IssuedClaims.AddRange(claims);
            
            //>Return
            return Task.FromResult(0);
        }
        public Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = _userManager.GetUserAsync(context.Subject).Result;
            
            context.IsActive = (user != null) && user.IsActive;
            //>Return
            return Task.FromResult(0);
        }
