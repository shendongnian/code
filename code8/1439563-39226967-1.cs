    public static string DecryptString(string Message, string Passphrase)
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
    
                 MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
                  
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                   
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    
                byte[] DataToDecrypt = Convert.FromBase64String(Message);
                // Step 5. Bat dau giai ma chuoi
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                catch (Exception) { Results = DataToDecrypt; }
                finally
                {                   
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }   
               
                return UTF8.GetString(Results);
            }
        }
