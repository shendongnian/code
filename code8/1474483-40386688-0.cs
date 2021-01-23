    public Task CreateAsync(ApplicationUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        var newUser = _permissionApiClient.Store(Mapper.Map<AccountDomainModel>(user)).Result;
        user.Id = newUser.AccountId;
        return Task.FromResult<Object>(null);
        //return thisUser;
    }
