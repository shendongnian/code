    public class Profile
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class LoginResponse
    {
        public string accessToken { get; set; }
        public string clientToken { get; set; }
        public Profile selectedProfile { get; set; }
        public List<Profile> availableProfiles { get; set; }
    }
