    byte[] dataToSign = Encoding.UTF8.GetBytes(plainText);
    var privKey = (RSACryptoServiceProvider)_certPopl.PrivateKey;
    // Force use of the Enhanced RSA and AES Cryptographic Provider with openssl-generated SHA256 keys
    var enhCsp = new RSACryptoServiceProvider().CspKeyContainerInfo;
    var cspparams = new CspParameters(enhCsp.ProviderType, enhCsp.ProviderName, privKey.CspKeyContainerInfo.KeyContainerName);
    privKey = new RSACryptoServiceProvider(cspparams);
    byte[] signature = privKey.SignData(dataToSign, "SHA256");
    // Verify signature
    if (!privKey.VerifyData(dataToSign, "SHA256", signature))
    	throw new Exception("Nepodařilo se vytvořit platný podpisový kód poplatníka.");
