    class LoginHttp{
    public static async Task<HttpResponseMessage> loginAsync(String username, String password)
    {
        var values = new Dictionary<string, string>
             {
              { "username",username },
              { "password", password }
            };
        var credentials = new FormUrlEncodedContent(values);
        var http = new HttpClient();
        var url = String.Format(shared.AppDetails.domainurl + "/v2auth/default/login");
        var response = await http.PostAsync(url, credentials);
        return response;
    }
