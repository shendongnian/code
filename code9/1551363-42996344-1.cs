    public static string GenerateSecret(string username, string token)
    {
        byte[] key;
        using (var md5 = MD5.Create())
        {
            key = md5.ComputeHash(Encoding.UTF8.GetBytes(username));
        }
        key = BytesToLowerHexBytes(key);
        var iv = Convert.FromBase64String(token);
        if (iv.Length != 16)
        {
            Array.Resize(ref iv, 16);
        }
        byte[] encrypted;
        using (var rijndael = new RijndaelManaged())
        {
            rijndael.Mode = CipherMode.CFB;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.KeySize = 256;
            using (var msEncrypt = new MemoryStream())
            {
                using (ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv))
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    var buffer = Encoding.UTF8.GetBytes(token);
                    csEncrypt.Write(buffer, 0, buffer.Length);
                }
                encrypted = msEncrypt.ToArray();
            }
        }
        var buffer2 = Encoding.UTF8.GetBytes(Convert.ToBase64String(encrypted));
        using (var ms = new MemoryStream(iv.Length + buffer2.Length))
        {
            ms.Write(iv, 0, iv.Length);
            ms.Write(buffer2, 0, buffer2.Length);
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
    }
    public static string ExtractSecret(string username, string encrypted)
    {
        byte[] key;
        using (var md5 = MD5.Create())
        {
            key = md5.ComputeHash(Encoding.UTF8.GetBytes(username));
        }
        key = BytesToLowerHexBytes(key);
        byte[] bytes = Convert.FromBase64String(encrypted);
        byte[] iv = bytes;
        Array.Resize(ref iv, 16);
        byte[] decrypted;
        using (var rijndael = new RijndaelManaged())
        {
            rijndael.Mode = CipherMode.CFB;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.KeySize = 256;
            using (var msDecrypt = new MemoryStream())
            {
                using (ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                {
                    var buffer = Convert.FromBase64String(Encoding.UTF8.GetString(bytes, 16, bytes.Length - 16));
                    csDecrypt.Write(buffer, 0, buffer.Length);
                }
                decrypted = msDecrypt.ToArray();
            }
        }
        return Encoding.UTF8.GetString(decrypted);
    }
    private static byte[] BytesToLowerHexBytes(byte[] bytes)
    {
        // The hash is a hex string
        var bytes2 = new byte[bytes.Length * 2];
        for (int i = 0, j = 0; i < bytes.Length; i++)
        {
            byte b1 = (byte)(bytes[i] >> 4);
            bytes2[j] = (byte)(b1 <= 9 ? '0' + b1 : 'a' + b1 - 10);
            j++;
            byte b2 = (byte)(bytes[i] & 15);
            bytes2[j] = (byte)(b2 <= 9 ? '0' + b2 : 'a' + b2 - 10);
            j++;
        }
        return bytes2;
    }
