        public byte[] Sign(string message)
        {
            using (var key = certificate.GetRSAPrivateKey())
            {
                return key.SignData(Encoding.UTF8.GetBytes(message),
                  HashAlgorithmName.SHA256,
                  RSASignaturePadding.Pkcs1);
            }
        }
