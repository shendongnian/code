     using (var random = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var key = new byte[16];
                random.GetBytes(key);
                using (System.Security.Cryptography.AesCryptoServiceProvider aesAlg = new System.Security.Cryptography.AesCryptoServiceProvider())
                {
                    aesAlg.BlockSize = 128;
                    aesAlg.KeySize = 128;
                    aesAlg.Key = key;
                    aesAlg.IV = key;
                    aesAlg.Mode = System.Security.Cryptography.CipherMode.CBC;
                    aesAlg.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                    using (ICryptoTransform iCryptoper = aesAlg.CreateEncryptor())
                    {
                        byte[] encryptedData = iCryptoper.TransformFinalBlock(x509CertData, 0, x509CertData.Length);
                        string encodedCert = Convert.ToBase64String(encryptedData);
                        System.Security.Cryptography.X509Certificates.X509Certificate2 x509Cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(x509CertData);
                        System.Security.Cryptography.RSACryptoServiceProvider provider = (System.Security.Cryptography.RSACryptoServiceProvider)x509Cert.PublicKey.Key;
                        byte[] encrypted = provider.Encrypt(aesAlg.Key, false);
                        string test = Convert.ToBase64String(encrypted);
                    }
                }
            }
