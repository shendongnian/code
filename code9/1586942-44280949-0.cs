     public static class Cryptography
        {
            private static readonly byte[] _keypassword = { 0x03, 0x02, 0x01, 0x00, 0x03, 0x02, 0x01, 0x00, 0x03, 0x02, 0x01, 0x00, 0x03, 0x02, 0x01, 0x00 };
            private static readonly byte[] _iVpassword = { 0x13, 0x12, 0x11, 0x10, 0x13, 0x12, 0x11, 0x10, 0x13, 0x12, 0x11, 0x10, 0x13, 0x12, 0x11, 0x10 };
    
            private static readonly byte[] _key = { 0x00, 0x01, 0x02, 0x03, 0x00, 0x01, 0x02, 0x03, 0x00, 0x01, 0x02, 0x03, 0x00, 0x01, 0x02, 0x03 };
            private static readonly byte[] _iV = { 0x10, 0x11, 0x12, 0x13, 0x10, 0x11, 0x12, 0x13, 0x10, 0x11, 0x12, 0x13, 0x10, 0x11, 0x12, 0x13 };
    
            #region Encryption
    
    
            public static string Encrypt(this string inputText)
            {
                string _encryptString = string.Empty;
                if (string.IsNullOrEmpty(inputText))
                    return string.Empty;
                else
                {
                    ASCIIEncoding textConverter = new ASCIIEncoding();
                    RijndaelManaged myRijndael = new RijndaelManaged();
    
                    ICryptoTransform encryptor = myRijndael.CreateEncryptor(_key, _iV);
                    MemoryStream msEncrypt = new MemoryStream();
                    CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                    byte[] toEncrypt = textConverter.GetBytes(inputText);
                    csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                    csEncrypt.FlushFinalBlock();
                    _encryptString = Convert.ToBase64String(msEncrypt.ToArray()).Replace(" ", "+");
                    return _encryptString;
                }
            }
    
            public static string Decrypt(this string inputText)
            {
                string text = inputText;
                try
                {
                    if (string.IsNullOrEmpty(inputText))
                        return string.Empty;
                    else
                    {
                        inputText = inputText.Replace(" ", "+");
    
                        byte[] encrypted = Convert.FromBase64String(inputText);
                        ASCIIEncoding textConverter = new ASCIIEncoding();
                        RijndaelManaged myRijndael = new RijndaelManaged();
    
                        ICryptoTransform decryptor = myRijndael.CreateDecryptor(_key, _iV);
                        MemoryStream msDecrypt = new MemoryStream(encrypted);
                        CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                        byte[] fromEncrypt = new byte[encrypted.Length];
                        csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                        return textConverter.GetString(fromEncrypt).TrimEnd('\x0');
                    }
                }
                catch (FormatException)
                {
                    return "";
                }
                catch (Exception ex)
                {
                    return text;
                }
            }
    
    
    
            #endregion Encryption
    
        }
