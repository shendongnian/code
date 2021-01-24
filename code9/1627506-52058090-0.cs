    services.AddAuthentication().AddFacebook("Facebook", options =>
    {
        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.ClientId = configuration.GetSection("ExternalLogin").GetSection("Facebook").GetSection("ClientId").Value;
        options.ClientSecret = configuration.GetSection("ExternalLogin").GetSection("Facebook").GetSection("ClientSecret").Value;
        options.Fields.Add("picture");
        options.Events = new OAuthEvents
        {
            OnCreatingTicket = context =>
            {
                var identity = (ClaimsIdentity)context.Principal.Identity;
                var profileImg = context.User["picture"]["data"].Value<string>("url");
                identity.AddClaim(new Claim(JwtClaimTypes.Picture, profileImg));
                return Task.CompletedTask;
            }
        };
    });
