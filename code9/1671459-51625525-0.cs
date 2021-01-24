    public static bool VerifyXml(XmlDocument Doc) 
    {
        if (Doc == null)
            throw new ArgumentException("Doc");
        SignedXml signedXml = new SignedXml(Doc);
        var nsManager = new XmlNamespaceManager(Doc.NameTable);
        nsManager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
        var node = Doc.SelectSingleNode("//ds:Signature", nsManager);
        // find signature node
        var certElement = Doc.SelectSingleNode("//ds:X509Certificate", nsManager);
        // find certificate node
        var cert = new X509Certificate2(Convert.FromBase64String(certElement.InnerText));            
        signedXml.LoadXml((XmlElement)node);
        //Find installed certificate from store
        X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
        store.Open(OpenFlags.ReadOnly);
        X509Certificate2 storeCert = store.Certificates.Find(X509FindType.FindBySerialNumber, cert.SerialNumber, true)[0];
        return signedXml.CheckSignature(storeCert, true);
        //^^^ If certificate is installed in the Root location then 
        //this method returns true after validating it as well
        //In addition to validating the signature
    }
