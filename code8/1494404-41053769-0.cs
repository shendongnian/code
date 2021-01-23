        private static bool Authenticate(string file, byte[] key, bool masterKey = false)
        {
            int position = 104;
            if (masterKey) position = 152; 
            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (var etm = new EtM_DecryptTransform(key, authenticateOnly: true))
            {
                fs.Position = position;
                using (var cs = new CryptoStream(fs, etm, CryptoStreamMode.Read))
                    cs.CopyTo(Stream.Null);
                if (!etm.IsComplete) throw new Exception("Some blocks were not authenticated");
            }
            return true;
        }        
        internal static void EncryptText(string text, Keyring k, string file, bool forSender)
        {
            SharedEphemeralBundle ephemeralBundle;
            if (forSender) ephemeralBundle = k.SenderDHM.GetSharedEphemeralDhmSecret();
            else ephemeralBundle = k.ReceiverDHM.GetSharedEphemeralDhmSecret();
            var ephemeralPublic = ephemeralBundle.EphemeralDhmPublicKeyBlob;
            var ephemeralSymmetric = ephemeralBundle.SharedSecret;
            var textBytes = text.ToBytes();                       
            using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {                
                fs.Write(ephemeralPublic, 0, ephemeralPublic.Length);
                using (var etm = new EtM_EncryptTransform(ephemeralSymmetric))
                using (var cs = new CryptoStream(fs, etm, CryptoStreamMode.Write))
                    cs.Write(textBytes, 0, textBytes.Length);                                                                                       
            }            
        }
        internal static string DecryptText(string file, Keyring k)
        {
            string decrypted = null;            
            var ephemeralPublic = new byte[104];
            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {                
                fs.Read(ephemeralPublic, 0, 104);
                var ephemeralSymmetric = k.SenderDHM.GetSharedDhmSecret(ephemeralPublic.ToPublicKeyFromBlob());
                if (Authenticate(file, ephemeralSymmetric))
                {
                    using (var etm = new EtM_DecryptTransform(ephemeralSymmetric))
                    using (var cs = new CryptoStream(fs, etm, CryptoStreamMode.Read))
                    {
                        var decrypt = new byte[fs.Length - 104];
                        cs.Read(decrypt, 0, decrypt.Length);
                        decrypted = decrypt.FromBytes();
                    }
                }                                                                                                          
            }
            return decrypted;
        }
