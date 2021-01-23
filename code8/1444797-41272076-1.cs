    // 1 Canonicalize the SignedInfo tag 
    XmlDsigExcC14NTransform serializer = new XmlDsigExcC14NTransform();
    XmlDocument doc = new XmlDocument();
    string toBeCanonicalized = signedInfoTag.InnerXml;
    doc.LoadXml(toBeCanonicalized);
    serializer.LoadInput(doc);
    string c14n = new StreamReader((Stream)serializer.GetOutput(typeof(Stream))).ReadToEnd();
    
    // 2 Hash the SignedInfo tag
    SHA256 HashAlg = SHA256.Create();
    byte[] hash = HashAlg.ComputeHash(Encoding.UTF8.GetBytes(c14n));
    
    // 3 Sign the hash
    byte[] signature;
    using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
    {
        csp.ImportParameters(((RSACryptoServiceProvider)mCertificate.PrivateKey)
           .ExportParameters(true));
        signature = csp.SignData(Encoding.UTF8.GetBytes(c14n), "SHA256");
    }
    signValueTag.InnerText = Convert.ToBase64String(signature);
