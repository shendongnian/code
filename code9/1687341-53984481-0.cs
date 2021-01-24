        AsymmetricCipherKeyPair GetKeyPairFromPrivateKey(AsymmetricKeyParameter privateKey)
        {
            AsymmetricCipherKeyPair keyPair = null;
            if (privateKey is RsaPrivateCrtKeyParameters rsa)
            {
                var pub = new RsaKeyParameters(false, rsa.Modulus, rsa.PublicExponent);
                keyPair = new AsymmetricCipherKeyPair(pub, privateKey);
            }
            else if (privateKey is Ed25519PrivateKeyParameters ed)
            {
                var pub = ed.GeneratePublicKey();
                keyPair = new AsymmetricCipherKeyPair(pub, privateKey);
            }
            else if (privateKey is ECPrivateKeyParameters ec)
            {
                var q = ec.Parameters.G.Multiply(ec.D);
                var pub = new ECPublicKeyParameters(ec.AlgorithmName, q, ec.PublicKeyParamSet);
                keyPair = new AsymmetricCipherKeyPair(pub, ec);
            }
            if (keyPair == null)
                throw new NotSupportedException($"The key type {privateKey.GetType().Name} is not supported.");
            return keyPair;
        }
