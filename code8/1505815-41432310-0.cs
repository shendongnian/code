    using (ICryptoTransform encryptor = encryptionAlgorithm.CreateEncryptor()) {
        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write)) {
            cryptoStream.Write(clearData, 0, clearData.Length);
            cryptoStream.FlushFinalBlock();
    
            // At this point:
            // memStream := IV || Enc(Kenc, IV, clearData)
    
            // These KeyedHashAlgorithm instances are single-use; we wrap it in a 'using' block.
            using (KeyedHashAlgorithm signingAlgorithm = _cryptoAlgorithmFactory.GetValidationAlgorithm()) {
                // Initialize the algorithm with the specified key
                signingAlgorithm.Key = _validationKey.GetKeyMaterial();
    
                // Compute the signature
                byte[] signature = signingAlgorithm.ComputeHash(memStream.GetBuffer(), 0, (int)memStream.Length);
    
                // At this point:
                // memStream := IV || Enc(Kenc, IV, clearData)
                // signature := Sign(Kval, IV || Enc(Kenc, IV, clearData))
    
                // Append the signature to the encrypted payload
                memStream.Write(signature, 0, signature.Length);
    
                // At this point:
                // memStream := IV || Enc(Kenc, IV, clearData) || Sign(Kval, IV || Enc(Kenc, IV, clearData))
    
                // Algorithm complete
                byte[] protectedData = memStream.ToArray();
                return protectedData;
            }
        }
    }
