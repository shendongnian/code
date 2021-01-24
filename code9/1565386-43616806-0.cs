    public String Decrypt(String text, String key)
    {
        //decode cipher text from base64
        byte[] cipher = Convert.FromBase64String(text);
        //get key bytes
        byte[] btkey = Encoding.ASCII.GetBytes(key);
        //init AES 128
        RijndaelManaged aes128 = new RijndaelManaged();
        aes128.Mode = CipherMode.ECB;
        aes128.Padding = PaddingMode.PKCS7;
        //decrypt
        ICryptoTransform decryptor = aes128.CreateDecryptor(btkey, null);
        MemoryStream ms = new MemoryStream(cipher);
        CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        byte[] plain = new byte[cipher.Length];
        int decryptcount = cs.Read(plain, 0, plain.Length);
        ms.Close();
        cs.Close();
        //return plaintext in String
        return Encoding.UTF8.GetString(plain, 0, decryptcount);
    }
