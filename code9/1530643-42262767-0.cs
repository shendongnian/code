    public async Task<bool> IsHostedTokenizeCardAllowedAsync(string businessGuid)
    {
        var b = await FindAsync(businessGuid);
        if (b.HostedPaymentEnabled)
            return true;
        else
            return false;
    }
