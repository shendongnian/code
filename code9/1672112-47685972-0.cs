    public virtual async Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
    {
        ...
        var store = GetEmailStore();
        ...
        await store.SetEmailConfirmedAsync(user, true, CancellationToken);
        return await UpdateUserAsync(user);
    }
