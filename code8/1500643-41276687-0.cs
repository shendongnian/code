        static void Main(string[] args)
        {
            var certificate = AuthenticateAzure("your domain name", "Ad App client ID", "username", "password");
        }
        /// <summary>
        ///  Log in to azure active directory in non-interactive mode using organizational
        //   id credentials and the default token cache. Default service settings (authority,
        //   audience) for logging in to azure resource manager are used.
        /// </summary>
        /// <param name="domainName"> The active directory domain or tenant id to authenticate with</param>
        /// <param name="nativeClientAppClientid">  The active directory client id for this application </param>
        /// <param name="userName"> The organizational account user name, given in the form of a user principal name  (e.g. user1@contoso.org).</param>
        /// <param name="password"> The organizational account password.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests  using the given credentials.</returns>
        private static ServiceClientCredentials AuthenticateAzure(string domainName, string nativeClientAppClientid,string userName,string password)
        {
           return UserTokenProvider.LoginSilentAsync(nativeClientAppClientid, domainName, userName, password).Result;
        }
