    // Your ASN.1/DER parser class
    AsnKeyParser keyParser = new AsnKeyParser("rsa-public.der");
    RSAParameters publicKey = keyParser.ParseRSAPublicKey();
    
    // .Net class
    CspParameters csp = new CspParameters;
    csp.KeyContainerName = "RSA Test (OK to Delete)";    
    csp.ProviderType = PROV_RSA_FULL;    // 1
    csp.KeyNumber = AT_KEYEXCHANGE;      // 1
    
    // .Net class
    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);
    rsa.PersistKeyInCsp = false;
    rsa.ImportParameters(publicKey);
