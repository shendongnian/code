    using (MemoryStream pfxData = new MemoryStream())
    {
        // **Change 1**: The DER Encoding is enabled on the
        // store builder
        Pkcs12StoreBuilder builder = new Pkcs12StoreBuilder();
        builder.SetUseDerEncoding(true);
        Pkcs12Store pkcsStore = builder.Build();
        // change - end
        X509CertificateEntry[] chain = new X509CertificateEntry[1];
        string certPassword = Guid.NewGuid().ToString();
        chain[0] = new X509CertificateEntry(x509);
        pkcsStore.SetKeyEntry(applicationName, new AsymmetricKeyEntry(subjectKeyPair.Private), chain);
        pkcsStore.Save(pfxData, certPassword.ToCharArray(), random);
        var pkcsPath = pkcsStorePath + "/pkcs.p12";
        File.WriteAllBytes(pkcsPath, pfxData.ToArray());
        // **Change 2**: Use certificate password
        certificate = new X509Certificate2(pkcsPath, certPassword);
        // **Change 3**: Possible to use array instead of filename
        // works as well. Just uncomment
        //certificate = new X509Certificate2(pfxData.ToArray(), certPassword);
    }
