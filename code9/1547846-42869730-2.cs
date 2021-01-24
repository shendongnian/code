    public class Settings
    {
        public static ICredentials ServiceCredential { get; set; }
        public static string AllUsersUri { get; set; }
    }
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class UserResponse
    {
        public IList<User> usersDetails { get; set; }
        public string errorMessage { get; set; }
    }
