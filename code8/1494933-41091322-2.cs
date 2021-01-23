    X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    certStore.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection certCollection = certStore.Certificates.Find(
                                     X509FindType.FindByThumbprint,
                                     // Replace below with yourcert's thumbprint
                                     "E661583E8FABEF4C0BEF694CBC41C28FB81CD870”,
                                     false);
