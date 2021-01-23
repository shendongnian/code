    private const string AesKey = "206283c07cbfda1c0c126ef56d78ba9a0aeb53a06cd65f10bd3a9cb9a68e3fe1";
    public static byte[] Encrypt(byte[] toEncrypt)
    {
        byte[] encrypted;
        var aes = new AesCryptoServiceProvider();
        aes.Key = StringToByteArray(AesKey);
        // Create a new IV for each item to encrypt
        aes.GenerateIV();
        byte[] iv = aes.IV;
        using (var encrypter = aes.CreateEncryptor(aes.Key, iv))
        using (var cipherStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
            using (var binaryWriter = new BinaryWriter(cryptoStream))
            {
                // Prepend unencrypted IV to data
                cipherStream.Write(iv, 0, iv.Length);
                binaryWriter.Write(toEncrypt);
                cryptoStream.FlushFinalBlock();
            }
            encrypted = cipherStream.ToArray();
        }
        return encrypted;
    }
    public static byte[] EncryptFromString(string toEncrypt)
    {
        return Encrypt(Encoding.UTF8.GetBytes(toEncrypt));
    }
    public static byte[] Decrypt(byte[] toDecrypt)
    {
        var aes = new AesCryptoServiceProvider();
        aes.Key = StringToByteArray(AesKey);
        // Pull out the unencrypted IV first
        byte[] iv = new byte[16];
        Array.Copy(toDecrypt, 0, iv, 0, iv.Length);
        using (var encryptedMemoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(encryptedMemoryStream, aes.CreateDecryptor(aes.Key, iv), CryptoStreamMode.Write))
            using (var binaryWriter = new BinaryWriter(cryptoStream))
            {
                // Decrypt Cipher Text from Message
                binaryWriter.Write(
                    toDecrypt,
                    iv.Length,
                    toDecrypt.Length - iv.Length
                );
            }
            return encryptedMemoryStream.ToArray();
        }
    }
    public static string DecryptToString(byte[] toDecrypt)
    {
        return Encoding.UTF8.GetString(Decrypt(toDecrypt));
    }
    public static string ByteArrayToString(byte[] array)
    {
        StringBuilder hex = new StringBuilder(array.Length * 2);
        foreach (byte b in array)
        {
            hex.AppendFormat("{0:x2}", b);
        }
        return hex.ToString();
    }
    public static byte[] StringToByteArray(string hex)
    {
        int charCount = hex.Length;
        byte[] bytes = new byte[charCount / 2];
        for (int i = 0; i < charCount; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
