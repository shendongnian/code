    public static sub Main()
    {
        arbitraryContainer
            .Register
            .ServiceFor<ISymmetricCryptor>()
            .Using<Aes256CbcCryptor>()
            .DependingOn(SomeConfigSomewhere.GetSetting["key"]);
        var cryptor = arbitraryContainer.Resolve<ISymmetricCryptor>();
        var cipherText = cryptor.Encrypt("P@55w0rd");
    }
