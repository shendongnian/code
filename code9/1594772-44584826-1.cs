    public List<X509Certificate2> GetPersonalCertificates()
    {
        var certificates = new List<X509Certificate2>();
        using (var store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
        {
            store.Open(OpenFlags.MaxAllowed);
    
            foreach (var certificate in store.Certificates)
            {
                if (certificate != null && certificate.HasPrivateKey && _canUsingCertificateForSignData(certificate.Extensions))
                {
                    certificates.Add(certificate);
                }
            }
        }
    
        return certificates;
    }
