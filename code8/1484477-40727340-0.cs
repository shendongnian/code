    public Task Send(ConsumeContext context, IPipe<ConsumeContext> next)
    {
        context.GetOrAddPayload(() => CreateAuthorizationContext());
        return next.Send(context);
    }
