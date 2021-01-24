    var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, keyBase64String , false);
    //var certCollection = store.Certificates.Find(X509FindType.FindByKeyUsage, keyBase64String , false);
    //var certCollection = store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, keyBase64String , false);
    var cert = certCollection[0];
