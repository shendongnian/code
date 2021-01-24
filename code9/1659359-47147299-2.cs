    public X509Certificate2 Load()
    {
        var thumbPrintFromConfig = ConfigurationManager.AppSettings["pfxthumbPrint"]
        var thumbPrint = Regex.Replace(thumbPrintFromConfig.ToUpper(),"[^A-F0-9]",""); //Keep only hex digits
        return Load(thumbPrint);
    }
    private X509Certificate2 Load(string thumbPrint)
    {
        using (var store = new X509Store(StoreName.My,StoreLocation.CurrentUser))
        {
            store.Open(OpenFlags.ReadOnly);
            var cert = store
                .Certificates
                .OfType<X509Certificate2>()
                .Where(x => x.Thumbprint == thumbPrint)
                .Single();
            store.Close();
            return cert;
        } 
    }
