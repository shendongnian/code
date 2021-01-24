    public class CustomPasswordHasher : IPasswordHasher<AppUser>
    {
        public string HashPassword(AppUser user, string password)
        {
            return password;
        }
        public PasswordVerificationResult VerifyHashedPassword(AppUser user, string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
