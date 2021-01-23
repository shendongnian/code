        public static string EncryptAES(string content, string password)
        {
            byte[] keyMaterial = Encoding.UTF8.GetBytes(password);
            byte[] data = Encoding.UTF8.GetBytes(content);
            byte[] iv = new byte[keyMaterial.Length];
            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);
            byte[] cipherText = WinRTCrypto.CryptographicEngine.Encrypt(key, data, iv);
            return Convert.ToBase64String(cipherText);
        }
        public static string DecryptAES(string content, string password)
        {
            byte[] keyMaterial = Encoding.UTF8.GetBytes(password);
            byte[] data = Convert.FromBase64String(content);
            byte[] iv = new byte[keyMaterial.Length];
            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);
            byte[] cipherText = WinRTCrypto.CryptographicEngine.Decrypt(key, data, iv);
            return Encoding.UTF8.GetString(cipherText, 0, cipherText.Length);
        }
