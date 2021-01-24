    private class AuthCredentials
    {
        public string ConsumerKey = "ConsumerKey";
        public string ConsumerSecret = "ConsumerSecret";
        public string AccessToken = "AccessToken";
        public string AccessTokenSecret = "AccessTokenSecret";
    }
    
    
    static void Main(string[] args)
    {
        var creds = new AuthCredentials();
        Auth.SetUserCredentials(creds.ConsumerKey, creds.ConsumerSecret, creds.AccessToken, creds.AccessTokenSecret);
        var data = File.ReadAllText("myimage.jpg");
        Account.UpdateProfileImage(data);
    }
