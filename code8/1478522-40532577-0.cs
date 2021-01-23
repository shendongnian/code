    var cryptoType = //get param
    if (cryptoType = "SHA1")
    {
        services.AddTransient<ICrypto, CryptoSHA1>();
    }
    else if (cryptoType = "MD5")
    {
        services.AddTransient<ICrypto, CryptoMD5>();
    }
