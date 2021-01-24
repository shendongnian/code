    var url = ConfigurationManager.AppSettings["UserAccessApi"];
    var credential = new CredentialCache
    {
     {
       new Uri(url), 
       "NTLM",
       new NetworkCredential(username, password)
      }
    };
    _client = new RestClient(url)
    {
         Authenticator = new NtlmAuthenticator(credentials)
    };
