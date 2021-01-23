        public static string Encrypt(string str, string key)
        {
            try
            {
                key = key.Replace(Environment.NewLine, "");
                IBuffer keyBuffer = CryptographicBuffer.DecodeFromBase64String(key);
                AsymmetricKeyAlgorithmProvider provider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1);
                var keyPar = provider.ImportKeyPair(keyBuffer, CryptographicPrivateKeyBlobType.Pkcs1RsaPrivateKey);
                //CryptographicKey publicKey = provider.ImportPublicKey(keyBuffer, CryptographicPublicKeyBlobType.Pkcs1RsaPublicKey);
                IBuffer dataBuffer = CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(str));
                var encryptedData = CryptographicEngine.Encrypt(keyPar, dataBuffer, null);
                var encryptedStr = CryptographicBuffer.EncodeToBase64String(encryptedData);
                var signature = CryptographicEngine.Sign(keyPar, dataBuffer);
                var signatureStr = CryptographicBuffer.EncodeToBase64String(signature);
                return encryptedStr;
            }
            catch (Exception e)
            {
                throw;
                return "Error in Encryption:With RSA ";
            }
        }
