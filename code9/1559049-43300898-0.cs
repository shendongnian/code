    [TestMethod]
    public async Task Test_SignInAsStudent()
    {
        Startup owinStartup = new Startup();
        Action<IAppBuilder> owinStartupAction = new Action<IAppBuilder>(owinStartup.Configuration);
        using (var server = TestServer.Create(owinStartupAction))
        {
            var req = server.CreateRequest("/authtoken");
            req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            // repeated code omitted
            // Is the access token of an appropriate length?
            string access_token = responseData["access_token"].ToString();
            Assert.IsTrue(access_token.Length > 32);
            AuthenticationTicket token = owinStartup.oabao.AccessTokenFormat.Unprotect(access_token);
            // now I can check whatever I want on the token.
        }
    }
