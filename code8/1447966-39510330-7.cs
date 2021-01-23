    public class TokenModel
    {
        public string f { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string ip { get; set; }
        public int expiration { get; set; }
        public string client { get; set; }
        public TokenModel(string username, string password, string ip, int expiration, string f = "json")
        {
            this.expiration = expiration;
            this.f = f;
            this.ip = ip;
            this.password = password;
            this.username = username;
        }
        public string GetQueryStringParameter()
        {
            return "f=" + this.f + "&username=" + this.username + "&password=" + this.password + "&ip=" + this.ip + "&expiration=" + this.expiration;
        }
    }
