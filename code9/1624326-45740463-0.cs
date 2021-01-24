    // initialize client for desired environment (for production change to www)
    var apiClient = new ApiClient("https://demo.docusign.net/restapi");
    Configuration.Default.ApiClient = apiClient;
	   
	   
    string username="[Email]";
    string password="[Password]";
    string integratorKey="[IntegratorKey]";
    // configure 'X-DocuSign-Authentication' header
    var authHeader = "{\"Username\":\"" + username + "\", \"Password\":\"" + password + "\", \"IntegratorKey\":\"" + integratorKey + "\"}";	   
    Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", authHeader);
	   
	   
    // login call is available in the authentication api 
    var authApi = new AuthenticationApi();
    LoginInformation loginInfo = authApi.Login();
