    IBuffer iv;                        // Initialization vector
    CryptographicKey key;              // Symmetric key
    UInt32 keyLength = 32;             // Length of the key, in bytes
    String strAlgName = SymmetricAlgorithmNames.AesCbc;
    
    // Initialize the initialization vector.
    iv = null;
    
    // Open a symmetric algorithm provider for the specified algorithm.
    SymmetricKeyAlgorithmProvider objAlg = SymmetricKeyAlgorithmProvider.OpenAlgorithm(strAlgName);
    
    // Determine whether the message length is a multiple of the block length.
    // This is not necessary for PKCS #7 algorithms which automatically pad the
    // message to an appropriate length.
    if (!strAlgName.Contains("PKCS7"))
    {
        if ((buffMsg.Length % objAlg.BlockLength) != 0)
        {
            throw new Exception("Message buffer length must be multiple of block length.");
        }
    }
    
    // Create a symmetric key.
    IBuffer keyMaterial = CryptographicBuffer.GenerateRandom(keyLength);
    key = objAlg.CreateSymmetricKey(keyMaterial);
    
    // CBC algorithms require an initialization vector. Here, a random
    // number is used for the vector.
    if (strAlgName.Contains("CBC"))
    {
        iv = CryptographicBuffer.GenerateRandom(objAlg.BlockLength);
    }
    
    // Encrypt the data and return.
    IBuffer buffEncrypt = CryptographicEngine.Encrypt(key, buffMsg, iv);
