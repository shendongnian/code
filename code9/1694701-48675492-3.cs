    private bool TlsValidationCallback(object sender, X509Certificate CACert, X509Chain CAChain, SslPolicyErrors sslPolicyErrors)
    {
        List<Oid> OIDExtractor = new List<Oid>();
        X509ChainElementCollection x509ChainElements = CAChain.ChainElements;
        foreach(X509ChainElement x509elm in x509ChainElements)
        {
            OIDExtractor.Add(new Oid(x509elm.Certificate.SignatureAlgorithm.Value));
        }
            
        if (sslPolicyErrors == SslPolicyErrors.None) 
            return true;
        X509Certificate2 _Certificate = new X509Certificate2(CACert);
        //If you needed/have to pass a certificate, add it here.
        //X509Certificate2 _CACert = new X509Certificate2(@"[localstorage]/ca.cert");
        //CAChain.ChainPolicy.ExtraStore.Add(_CACert);
        CAChain.Build(_Certificate);
        foreach (X509ChainStatus CACStatus in CAChain.ChainStatus)
        {
            if ((CACStatus.Status != X509ChainStatusFlags.NoError) &
                (CACStatus.Status != X509ChainStatusFlags.UntrustedRoot))
                return false;
        }
        return true;
    }
