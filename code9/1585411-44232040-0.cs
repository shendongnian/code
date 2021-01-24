    public override Task CreateAsync(AuthenticationTokenCreateContext context)
    {
        ...
        // One hour
        int expire = 60 * 60;
        context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddSeconds(expire));
        ...
    }
