    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection certs = store.Certificates.Find(
        X509FindType.FindByIssuerName, "TEST", false); 
        //Change FindType to your liking, it doesn't support FriendlyName, 
        //maybe use your method?
    WebRequestHandler handler = new WebRequestHandler();
    X509Certificate2 certificate = GetMyX509Certificate();
    handler.ClientCertificates.Add(certificate);
    HttpClient client = new HttpClient(handler);
