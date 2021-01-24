    public DocuSignClient(Credentials credentials)
    {
          // initialize client for desired environment (for production change to www)
          ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
          Configuration.Default.ApiClient = apiClient;
          // configure 'X-DocuSign-Authentication' header
          string authHeader = "{\"Username\":\"" + credentials.Username + "\", \"Password\":\"" + credentials.Password + "\", \"IntegratorKey\":\"" + credentials.IntegratorKey + "\"}";
          if (!Configuration.Default.DefaultHeader.ContainsKey("X-DocuSign-Authentication"))
          {
              Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", authHeader);
          }
          WebProxy webProxy = new WebProxy("http://proxy.corp.ups.com:8080", true)
          {
              UseDefaultCredentials = false,
              Credentials = new NetworkCredential("ABC", "XYZ")
          };
          apiClient.RestClient.Proxy = webProxy;
          // login call is available in the authentication api 
          AuthenticationApi authApi = new AuthenticationApi();
          LoginInformation loginInfo = authApi.Login();
          // parse the first account ID that is returned (user might belong to multiple accounts)
          this.AccountId = loginInfo.LoginAccounts[0].AccountId;
     }
