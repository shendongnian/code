    public X509Certificate2 Load()
    {
        var thumbPrintFromConfig = ConfigurationManager.AppSettings["pfxthumbPrint"]
        var thumbPrint = Regex.Replace(thumbPrintFromConfig.ToUpper(),"^[0-9a-fA-F]+$",""); //Keep only hex digits
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
