    public virtual async Task<IdentityManagerResult> SetUserPropertyAsync(string subject, string type, string value)
    {
        TUserKey key = ConvertUserSubjectToKey(subject);
        var user = await this.userManager.FindByIdAsync(key);
        // [...]
        var metadata = await GetMetadataAsync();
        var propResult = SetUserProperty(metadata.UserMetadata.UpdateProperties, user, type, value);
        if (!propResult.IsSuccess)
        {
            return propResult;
        }
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return new IdentityManagerResult(result.Errors.ToArray());
        }
        return IdentityManagerResult.Success;
    }
