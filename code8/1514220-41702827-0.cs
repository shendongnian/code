    string base64 = File.ReadAllText(strInputFile);
    byte[] decoded = Convert.FromBase64String(base64);
    using (Aes aes = Aes.Create())
    using (ICryptoTransform decryptor = aes.CreateDecryptor(bytKey, bytIV))
    using (var fsOutput = File.Create(strOutputFile))
    using (var cryptoStream = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write))
    {
        cryptoStream.Write(decoded, 0, decoded.Length);
    }
