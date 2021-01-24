    public override async Task<bool> IsGrantedAsync(long userId, string permissionName)
    {
        if (permissionName == MyClientIpAddressPermissionName)
        {
            return ClientInfoProvider.ClientIpAddress == "192.168.5.2";
        }
        return await base.IsGrantedAsync(userId, permissionName);
    }
