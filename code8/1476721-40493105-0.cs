    try
    {
        ICspAsymmetricAlgorithm key = cert.PrivateKey;
        if (key != null)
        {
            return key.CspKeyContainerInfo.Exportable;
        }
    }
    catch (CryptographicException) {}
    return whateverYouWantUnknownToBe;
