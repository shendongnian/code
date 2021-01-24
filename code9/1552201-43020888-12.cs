    public async Task<bool> EnsureAuthenticated()
    {
        return (IsAuthenticated || (await Authenticate()).IsSuccess)
            ? true
            : throw new AuthenticationException();
    }
