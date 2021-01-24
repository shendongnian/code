    public override object Authenticate(
        IServiceBase authService, IAuthSession session, Authenticate request)
    {
        var response = base.Authenticate(authService, session, request);
        if (response is AuthenticateResponse authDto)
        {
            authDto.Meta = new Dictionary<string,string> { ... }
        }
        return response;
    }
