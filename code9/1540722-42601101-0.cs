    using (var rsa = new RSACryptoServiceProvider(KEY_SIZE))
    {
        publicKeyAlice = rsa.ExportCspBlob(false);
        privateKeyAlice = rsa.ExportCspBlob(true);
    }
    using (var rsa = new RSACryptoServiceProvider(KEY_SIZE))
    {
        privateKeyBob = rsa.ExportCspBlob(true);
        publicKeyBob = rsa.ExportCspBlob(false);
    }
