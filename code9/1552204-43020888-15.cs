    public async Task EnsureAuthenticated()
    {
        if (!(IsAuthenticated || (await Authenticate()).IsSuccess))
        {
            throw new AuthenticationException();
        }
    }
