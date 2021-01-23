    XmlDocument publicXmlParam = new XmlDocument();
    publicXmlParam.Load("C:\\rsapublicprivate.xml");
    // Here I "utilize my own 2048 keys"
    RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
    //This was the trick, we pass the RSA parameters as XML into the provider.           
    provider.FromXmlString(publicXmlParam.OuterXml); 
    // Then we use the provider in the constructor of the RsaSecurityKey
    var key = new RsaSecurityKey(provider); 
    signingCredentials = 
        new SigningCredentials(
            key, 
            SecurityAlgorithms.RsaSha256Signature,   
            SecurityAlgorithms.Sha256Digest); 
