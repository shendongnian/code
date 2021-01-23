    public Task Consume(ConsumeContext<MyMessage> context)
    {
        var authorizationContext = context.GetPayload<AuthorizationContext>();
        if(authorizationContext.IsAdmin)
            return UpdateSomething(context);
        throw new NotAuthorizationException("Booo!");
    }
