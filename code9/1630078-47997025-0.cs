    services.AddAuthentication().AddFacebook(options =>
    {
        options.ClientId = Configuration.GetSection("Facebook:ApplicationId").Value;
        options.ClientSecret = Configuration.GetSection("Facebook:Password").Value;
        options.Events = new OAuthEvents
        {
            OnCreatingTicket = context =>
            {
                // do something with context
                return Task.FromResult<object>(null);
            }
        };
    });
