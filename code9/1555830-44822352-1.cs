            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId =     "-----copy from your facebook app-----",
                AppSecret = "-----copy from your facebook app-----",
                Provider = new FacebookAuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
                        return Task.FromResult(true);
                    }
                },
                //BackchannelHttpHandler = new FacebookBackChannelHandler(),
                //UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location"
            };
            facebookOptions.Scope.Add("email");
            //facebookOptions.Scope.Add("user_likes");
            app.UseFacebookAuthentication(facebookOptions);
