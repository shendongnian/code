    const int PROV_RSA_AES = 24;
    CspParameters cspParameters = new CspParameters(PROV_RSA_AES)
    {
        KeyNumber = (int)KeyNumber.Exchange,
        KeyContainerName = KeyName,
        Flags = CspProviderFlags.UseNonExportableKey, // Or whatever.
    };
    // This constructor is open-or-create since flags didn't asset ExistingOnly.
    using (RSA rsa = new RSACryptoServiceProvider(Size, cspParameters))
    {
        // tada.  Use CNG instead, if you can.
    }
