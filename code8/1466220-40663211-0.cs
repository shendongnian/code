        public static AsymmetricAlgorithm ToDotNetKey(RsaPrivateCrtKeyParameters privateKey)
        {
            var cspParams = new CspParameters
            {
                ProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider",
                ProviderType = 24,
                KeyContainerName = KEY_CONTAINER_NAME,
                KeyNumber = (int)KeyNumber.Signature,
                Flags = CspProviderFlags.UseMachineKeyStore
            };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);
            RSAParameters parameters = new RSAParameters
            {
                Modulus = privateKey.Modulus.ToByteArrayUnsigned(),
                P = privateKey.P.ToByteArrayUnsigned(),
                Q = privateKey.Q.ToByteArrayUnsigned(),
                DP = privateKey.DP.ToByteArrayUnsigned(),
                DQ = privateKey.DQ.ToByteArrayUnsigned(),
                InverseQ = privateKey.QInv.ToByteArrayUnsigned(),
                D = privateKey.Exponent.ToByteArrayUnsigned(),
                Exponent = privateKey.PublicExponent.ToByteArrayUnsigned()
            };
            rsaProvider.ImportParameters(parameters);
            
            return rsaProvider;
        }
