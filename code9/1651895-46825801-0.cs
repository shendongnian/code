    public virtual async Task<IdentityResult> LockUserAccount(string userId, int? forDays)
    {
        var result = await this.SetLockoutEnabledAsync(userId, true);
        if (result.Succeeded)
        {
            if (forDays.HasValue)
            {
                result = await SetLockoutEndDateAsync(userId, DateTimeOffset.UtcNow.AddDays(forDays.Value));
            }
            else
            {
                result = await SetLockoutEndDateAsync(userId, DateTimeOffset.MaxValue);
            }
        }
        return result;
    }
    public virtual async Task<IdentityResult> UnlockUserAccount(string userId)
    {
        var result = await this.SetLockoutEnabledAsync(userId, false);
        if (result.Succeeded)
        {
            await ResetAccessFailedCountAsync(userId);
        }
        return result;
    }
