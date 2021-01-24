    private static void CreateTokenPassport()
    {
        // Initialize the netsuite web service proxy.
        _netSuiteService = new NetSuiteService();
        
        // A valid Token passport signature consists of the following:
        // Create a base string.
        //     The base string is variable created from concatenating a series of values specific to the request.Use an ampersand as a delimiter between values.
        //     The values should be arranged in the following sequence:
        // NetSuite account ID
        // Consumer key
        // Token
        // Nonce(a unique, randomly generated alphanumeric string, with a minimum of six characters and maximum of 64)
        // Timestamp
        // See: https://system.na1.netsuite.com/app/help/helpcenter.nl?fid=section_4395630653.html#bridgehead_4398049137
        
        string consumerSecret = "";
        string tokenSecret = "";
        string accountId = "";
        string consumerKey = "";
        string tokenId = "";
        string nonce = ComputeNonce();
        long timestamp = ComputeTimestamp();
        
        string baseString = string.Format("{0}&{1}&{2}&{3}&{4}", accountId, consumerKey, tokenId, nonce, timestamp);
        string secretKey = string.Format("{0}&{1}", consumerSecret, tokenSecret);
        
        // Initialize the keyed hash object using the secret key as the key
        HMACSHA256 hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
        
        // Computes the signature by hashing the data with the secret key as the key
        byte[] signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(baseString));
        
        // Base 64 Encode
        string encodedSignature = Convert.ToBase64String(signature);
        
        TokenPassport tokenPassport = new TokenPassport
        {
            signature = new TokenPassportSignature
            {
                Value = encodedSignature,
                algorithm = "HMAC_SHA256"
            },
            account = accountId,
            consumerKey = consumerKey,
            token = tokenId,
            nonce = nonce,
            timestamp = timestamp
        };
        
        _netSuiteService = new NetSuiteService
        {
            tokenPassport = tokenPassport
        };
    }
