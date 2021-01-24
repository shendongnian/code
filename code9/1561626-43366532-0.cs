    public class LoginData {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Nonce { get; set; }
        public string Language { get; set; }
        public bool SaveCredentials { get; set; }
    }
    public class UpdateModel {
        public LoginData oldCredentials { get; set; }
        public string newPassword { get; set; }
    }
