    CngKey key = null;
    try
    {
        key = CngKey.Open(KeyName);
    }
    catch (CryptographicException)
    {
        // This is only in the catch block to avoid a scrollbar.
        CngKeyCreationParameters creationParameters = new CngKeyCreationParameters()
        {
            ExportPolicy = CngExportPolicies.None, // Or whatever.
            Provider = CngProvider.MicrosoftSoftwareKeyStorageProvider,
            KeyCreationOptions = CngKeyCreationOptions.OverwriteExistingKey,
            Parameters =
            {
                new CngProperty("Length", BitConverter.GetBytes(Size), CngPropertyOptions.None),
            }
        };
        cngKey = CngKey.Create(CngAlgorithm.Rsa, KeyName, creationParameters);
    }
    using (cngKey)
    using (RSA rsa = new RSACng(cngKey))
    {
        // Tada.
    }
