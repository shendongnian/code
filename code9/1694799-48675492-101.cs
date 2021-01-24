    private bool TlsValidationCallback(object sender, X509Certificate CACert, X509Chain CAChain, SslPolicyErrors sslPolicyErrors)
    {
        List<Oid> oidExtractor = CAChain
                                 .ChainElements
                                 .Cast<X509ChainElement>()
                                 .Select(x509 => new Oid(x509.Certificate.SignatureAlgorithm.Value))
                                 .ToList();
        // Inspect the oidExtractor list
        if (sslPolicyErrors == SslPolicyErrors.None) 
            return true;
        X509Certificate2 certificate = new X509Certificate2(CACert);
        //If you needed/have to pass a certificate, add it here.
        //X509Certificate2 cert = new X509Certificate2(@"[localstorage]/[ca.cert]");
        //CAChain.ChainPolicy.ExtraStore.Add(cert);
        CAChain.Build(certificate);
        foreach (X509ChainStatus CACStatus in CAChain.ChainStatus)
        {
            if ((CACStatus.Status != X509ChainStatusFlags.NoError) &
                (CACStatus.Status != X509ChainStatusFlags.UntrustedRoot))
                return false;
        }
        return true;
    }
