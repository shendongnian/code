    public override Task CreateAsync(AuthenticationTokenCreateContext context)
    {
        var form = context.Request.ReadFormAsync().Result;
        var grantType = form.GetValues("grant_type");
        if (grantType[0] != "refresh_token")
        {
            ...
            // One day
            int expire = 24 * 60 * 60;
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddSeconds(expire));
        }
        base.Create(context);
    }
