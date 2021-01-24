    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
    {
        bool result = false;
        X509Certificate2 cert2 = (X509Certificate2)cert;
        X509Store store = new X509Store(StoreName.Root);
        store.Open(OpenFlags.ReadOnly);
        X509Certificate2Collection cc = store.Certificates.Find(X509FindType.FindByThumbprint, chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint, true);
        store.Close();
        if (cc.Count > 0)
        {
            result = true;
        }
        return result;
    }
