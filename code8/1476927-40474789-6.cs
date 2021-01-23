    public String SampleDeriveFromPbkdf(
        String strAlgName,
        UInt32 targetSize)
    {
        // Open the specified algorithm.
        KeyDerivationAlgorithmProvider objKdfProv = KeyDerivationAlgorithmProvider.OpenAlgorithm(strAlgName);
        // Create a buffer that contains the secret used during derivation.
        String strSecret = "MyPassword";
        IBuffer buffSecret = CryptographicBuffer.ConvertStringToBinary(strSecret, BinaryStringEncoding.Utf8);
        // Create a random salt value.
        IBuffer buffSalt = CryptographicBuffer.GenerateRandom(32);
        // Specify the number of iterations to be used during derivation.
        UInt32 iterationCount = 10000;
        // Create the derivation parameters.
        KeyDerivationParameters pbkdf2Params = KeyDerivationParameters.BuildForPbkdf2(buffSalt, iterationCount);
        // Create a key from the secret value.
        CryptographicKey keyOriginal = objKdfProv.CreateKey(buffSecret);
        // Derive a key based on the original key and the derivation parameters.
        IBuffer keyDerived = CryptographicEngine.DeriveKeyMaterial(
            keyOriginal,
            pbkdf2Params,
            targetSize);
        // Encode the key to a hexadecimal value (for display)
        String strKeyHex = CryptographicBuffer.EncodeToHexString(keyDerived);
        // Return the encoded string
        return strKeyHex;
    }
