    var option = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions();
    option.AppId = ConfigurationManager.AppSettings.Get("fbAppId");
    option.AppSecret = ConfigurationManager.AppSettings.Get("fbAppSecret");
    option.Scope.Add("email");
    option.UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=name,email";
    app.UseFacebookAuthentication(option);
