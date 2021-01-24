    public class ApplicationSignInManager : SignInManager<ApplicationUser, Guid>
    {
        
        // adjust as needed
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
        public Task<SignInStatus> PasswordSignInAsync(string userId, string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var user = await base.UserManager.FindByIdAsync(userId);
            // do validation for user, etc.
            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }
    }
