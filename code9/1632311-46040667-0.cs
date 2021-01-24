    private static RSACryptoServiceProvider AssociateHwnd(
        RSACryptoServiceProvider rsaCsp,
        IntPtr hwnd)
    {
        CspKeyContainerInfo containerInfo = rsaCsp.CspKeyContainerInfo;
        CspParameters newParameters = new CspParameters(
            containerInfo.ProviderType,
            containerInfo.ProviderName,
            containerInfo.KeyContainerName)
        {
            KeyNumber = (int)containerInfo.KeyNumber,
            Flags = CspProviderFlags.UseExistingKey,
            ParentWindowHandle = hwnd,
        };
        if (containerInfo.MachineKeyStore)
        {
            newParameters.Flags |= CspProviderFlags.UseMachineKeyStore;
        }
        return new RSACryptoServiceProvider(newParameters);
    }
