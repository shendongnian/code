        public static string EncryptString(string message, string KeyString, string IVString)
        {
            byte[] Key = UTF8Encoding.UTF8.GetBytes(KeyString).Take(32).ToArray();
            if (Key.Length < 32)
                throw new Exception("KeyString not at least 32 bytes.");
            byte[] IV = UTF8Encoding.UTF8.GetBytes(IVString).Take(16).ToArray();
            if (Key.Length < 32)
                throw new Exception("IVString not at least 16 bytes.");
            string encrypted = null;
            RijndaelManaged rj = new RijndaelManaged();
            rj.KeySize = 128;
            rj.BlockSize = 128;
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;
            rj.Padding = PaddingMode.PKCS7;
            try
            {
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);
                ms.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
            finally
            {
                rj.Clear();
            }
            return encrypted;
        }
