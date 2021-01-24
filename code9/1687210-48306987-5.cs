        public static class QueryCrypto
        {
            private static byte[] Key = new byte[24];
    
            static QueryCrypto()
            {
                (new RNGCryptoServiceProvider()).GetBytes(Key);
            }
    
            public static string Encrypt(string toencrypt, string key = "", bool usehashing = true)
            {
                if (key.Length == 0)
                    key = Key.ToString();
    
                byte[] keyArray;
    
                // If hashing use get hash code regards to your key
                if (usehashing)
                {
                    using (var hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    }
                }
                else
                {
                    keyArray = Encoding.UTF8.GetBytes(key);
                }
    
                // set the secret key for the tripleDES algorithm
                // mode of operation. there are other 4 modes.
                // We choose ECB(Electronic code Book)
                // padding mode(if any extra byte added)
                using (var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                using (var transform = tdes.CreateEncryptor())
                {
                    try
                    {
                        var toEncryptArray = Encoding.UTF8.GetBytes(toencrypt);
    
                        // transform the specified region of bytes array to resultArray
                        var resultArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
    
                        // Return the encrypted data into unreadable string format
                        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
    
            public static string Decrypt(string todecrypt, string key = "", bool usehashing = true)
            {
                if (key.Length == 0)
                    key = Key.ToString();
    
                byte[] toEncryptArray;
    
                // get the byte code of the string
                try
                {
                    toEncryptArray = Convert.FromBase64String(todecrypt.Replace(" ", "+")); // The replace happens only when spaces exist in the string (hence not a Base64 string in the first place).
                }
                catch (Exception)
                {
                    return string.Empty;
                }
    
                byte[] keyArray;
    
                if (usehashing)
                {
                    // if hashing was used get the hash code with regards to your key
                    using (var hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    }
                }
                else
                {
                    // if hashing was not implemented get the byte code of the key
                    keyArray = Encoding.UTF8.GetBytes(key);
                }
    
                // set the secret key for the tripleDES algorithm
                // mode of operation. there are other 4 modes. 
                // We choose ECB(Electronic code Book)
                // padding mode(if any extra byte added)
                using (var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                using (var transform = tdes.CreateDecryptor())
                {
                    try
                    {
                        var resultArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
    
                        // return the Clear decrypted TEXT
                        return Encoding.UTF8.GetString(resultArray);
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
            }
