    interface IPasswordUtilities {
        // NOTE: I believe GenerateRandomSalt is an implementation detail;
        // it should not be part of the interface
        string HashPassword(string plainPassword);
    }
    interface IAuthenticationHandler {
        void Authenticate(string username, string password);
    }
    class PasswordUtilities : IPasswordUtilities {
        // implementation
    }
    class AuthenticationHandler : IAuthenticationHandler {
        public AuthenticationHandler(IUserHandler userHandler, IPasswordUtilities utilities) { 
            ... 
        }
    }
    class UserHandler : IU+serHandler {
        public UserHandler(IPasswordUtilities utilities) { ... }
        public void AddUser(User user) {
            string hashedPassword = _utilities.HashPassword(user.Password.HashedPassword);
        }
    }
