    public class ClearPassword : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }
    }
