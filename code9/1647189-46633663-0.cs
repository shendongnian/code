    string userId = "1234567892";
    string password = "123456789";
    var loginRequest = new loginRequest(userId, password);
    var proxy = new ProcessMakerServiceSoapClient();
    var loginResult = proxy.loginAsync(loginRequest);
    var result = loginResult.Result;
    proxy.Close();
