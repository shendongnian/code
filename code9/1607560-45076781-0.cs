        InstaApi _instaApi;
        var userSession = new UserSessionData
        {
            UserName = "",
            Password = ""
        };
        HttpClientHandler handler = new HttpClientHandler()
        {
            Proxy = new WebProxy("http://127.0.0.1:8888"),
            UseProxy = true,
        };
        _instaApi = new InstaApiBuilder()
                .SetUser(userSession)
                .UseHttpClientHandler(handler)
                .Build(); 
