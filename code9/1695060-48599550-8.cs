    public override async Task<bool> IsGrantedAsync(long userId, string permissionName)
    {
        if (permissionName == MyClientIpAddressPermissionName)
        {return Task.Run(() => { return _clientInfoProvider.ClientIpAddress == "192.168.5.2"; });
        }
        return await base.IsGrantedAsync(userId, permissionName);
    }
