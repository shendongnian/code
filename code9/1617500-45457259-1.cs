     public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
        CustomIdentityService _customIdentityService = new CustomIdentityService();
        ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,OAuthDefaults.AuthenticationType);
        ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,CookieAuthenticationDefaults.AuthenticationType);
        //Add custom claims code
        string fooInfo= _customIdentityService.FooInfo(user.Id));
        oAuthIdentity.AddClaim(new Claim("fooInfo", fooInfo));
        AuthenticationProperties properties = CreateProperties(user.UserName,fooInfo);
        }
        
      public static AuthenticationProperties CreateProperties(string userName,string fooInfo)
        {
           IDictionary<string, string> data = new Dictionary<string, string>
         {
            { "fooInfo", fooInfo },
            { "userName", userName }
         };
           return new AuthenticationProperties(data);
         }
