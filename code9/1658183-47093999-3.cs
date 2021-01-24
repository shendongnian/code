    public class EncryptionAES128
        {
         static public string EncryptString(string inputString, string key)
                {
                    string output = "";
    
    
                    Rijndael encryption = new RijndaelManaged();
    
                    try
                    {
                        encryption.IV = GenerateIV();
                        encryption.Key = StringToByte(key);
    
                        ICryptoTransform encryptor = encryption.CreateEncryptor(encryption.Key, encryption.IV);
    
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(inputString);
                                }
    
                                byte[] cipherText = msEncrypt.ToArray();
                                byte[] encrypted = new byte[cipherText.Length + encryption.IV.Length];
    
                                encryption.IV.CopyTo(encrypted, 0);
                                cipherText.CopyTo(encrypted, IV_LENGTH);
    
                                output = ByteToString(encrypted);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
    
    
                    return output;
