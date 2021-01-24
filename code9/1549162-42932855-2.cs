    var payload = new Dictionary<string, object>()
    {
       { "sub", "mr.x@contoso.com" },
       { "exp", 1300819380     }
    };
    var certificate = X509Certificate.CreateFromCertFile("public.cer");
    byte[] publicKey = certificate.GetPublicKey(); //public key has 65 bytes
    //Discard the first byte (it is always 0X04 for ECDSA public key)
    publicKey = publicKey.Skip(1).ToArray();:
    //Generate 4 bytes for curve and 4 bytes for key length [ 69(E), 67(C), 83(S), 49(1), 32(Key length), 0, 0, 0 ]
    byte[] x = { 69, 67, 83, 49, 32, 0, 0, 0 };    
    //Prefix above generated array to existing public key array
    publicKey = x.Concat(publicKey).ToArray();
    var cng = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob); //This works
    return JWT.Encode(claims, cng, JwsAlgorithm.ES256); //Now this is throwing error
