    public static bool VerifyXml(XmlDocument Doc) {
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
        return signedXml.CheckSignature(cert);
    }
