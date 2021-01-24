            byte[] iv = null; // get iv form pw
            byte[] key = null; // get key from pw
            using (AesManaged cryptor = new AesManaged())
            {
                ivhex = BitConverter.ToString(iv).Replace("-", string.Empty);
                keyhex = BitConverter.ToString(key).Replace("-", string.Empty);
                // Encrypt File
                using (var ms = new MemoryStream())
                {
                    cryptor.Mode = CipherMode.CBC;
                    cryptor.Padding = PaddingMode.PKCS7;
                    cryptor.KeySize = 256;
                    cryptor.BlockSize = 256;
                    //We use the random generated iv created by AesManaged
                    using (CryptoStream cs = new CryptoStream((Stream)ms, cryptor.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(cs))
                        {
                            
                                swEncrypt.Write(text);
                            
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
