    public class PasswordHasherWithOldHashingSupport : IPasswordHasher<ApplicationUser>
    {
        private readonly IPasswordHasher<ApplicationUser> _identityPasswordHasher;
        public PasswordHasherWithOldHashingSupport()
        {
            _identityPasswordHasher = new PasswordHasher<ApplicationUser>();
        }
        public string HashPassword(ApplicationUser user, string password)
        {
            return _identityPasswordHasher.HashPassword(user, password);
        }
        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            var passwordVerificationResult = _identityPasswordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                /* Do your custom verification logic and if successful, return PasswordVerificationResult.SuccessRehashNeeded */
                passwordVerificationResult = PasswordVerificationResult.SuccessRehashNeeded;
            }
            return passwordVerificationResult;
        }
    }
