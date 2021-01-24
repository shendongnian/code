    using (MemoryStream ms = new MemoryStream())
    {
        using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
        {
            cs.Write(cipherText_only, 0, cipherText_only.Length);
        }
        
        byte[] decrypted = ms.ToArray();
        string decr_serverSays = Encoding.UTF8.GetString(decrypted);
        Debug.Log (decr_serverSays + "..." + decr_serverSays.Length.ToString());
        return decr_serverSays;
    }
