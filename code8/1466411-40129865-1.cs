    public static sub Main()
    {
        var key = SomeConfigSomewhere.GetSetting["key"];
        var cryptor = new Aes256CbcCryptor(key);
        var cipherText = cryptor.Encrypt("P@55w0rd");
    }
