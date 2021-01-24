    public async Task<bool> EnsureAuthenticated()
    {
        if (!(IsAuthenticated || (await Authenticate()).IsSuccess))
        {
            throw new AuthenticationException();
        }
        return true;
    }
