    byte[] decryptedBytes = null;
    byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
    AES.Key = key.GetBytes(AES.KeySize / 8);  // ---> 256 / 8 = 32
    AES.IV = key.GetBytes(AES.BlockSize / 8); // ---> 128 / 8 = 16
    AES.Mode = CipherMode.CBC;
    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(),    CryptoStreamMode.Write))
    {
        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                cs.Close();
    }
    decryptedBytes = ms.ToArray();
