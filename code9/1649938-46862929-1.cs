    public class SocialConfig
        {
            public SocialApp Facebook { get; set; }
        }
    
        public class SocialApp
        {
            public string AppId { get; set; }
            public string AppSecret { get; set; }
        }
    
        public class User
        {
            public Guid Id { get; set; }
            public string SocialUserId { get; set; }
            public string Email { get; set; }
            public bool IsVerified { get; set; }
            public string Name { get; set; }
    
            public User()
            {
                IsVerified = false;
            }
        }
    
        public class ExternalToken
        {
            public string Provider { get; set; }
            public string Token { get; set; }
        }
