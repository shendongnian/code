    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        protected override async Task<bool> VerifyPasswordAsync(
              IUserPasswordStore<ApplicationUser, string> store, 
              ApplicationUser user, string password)
        {
            var hash = await store.GetPasswordHashAsync(user);
            var verifyRes = PasswordHasher.VerifyHashedPassword(hash, password);
            if (verifyRes == PasswordVerificationResult.SuccessRehashNeeded)
               await store.SetPasswordHashAsync(user, PasswordHasher.HashPassword(password));
            return verifyRes != PasswordVerificationResult.Failed;
        }
    }
