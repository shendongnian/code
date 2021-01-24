    public ApiClient GetApiClient()
    {
        try
        {
            String apiURL = ConfigurationManager.AppSettings["API_URL"];
            apiClient = new ApiClient(apiURL);
            // Auth to the API to get our JWT token for subsequent requests.
            var request = new AuthRequest()
            {
                Type = UserType.Staff,
                Username = ConfigurationManager.AppSettings["API_UserName"],
                Password = ConfigurationManager.AppSettings["API_Password"]
            });
            AuthResponse response = Authenticate(apiClient, request);
            if (response != null)
            {
                //save the token for all subsequent requests
                apiClient.JwtToken = response.Token;
                response = null;
            }
            else
            {
                log.Error("APIClient Could not authenticate.");
            }
            return apiClient;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal virtual AuthResponse Authenticate(ApiClient apiClient, AuthRequest request)
    {
        return apiClient.Authenticate(request);
    }
