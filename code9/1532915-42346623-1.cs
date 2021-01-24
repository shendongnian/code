    public static ISession SafeSession(this HttpContext httpContext)
    {
        var sessionFeature = httpContext.Features.Get<ISessionFeature>();
        return sessionFeature == null ? null : httpContext.Session;
    }
