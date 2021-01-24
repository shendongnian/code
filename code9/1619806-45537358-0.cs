    string toEncrypt = "SecretText";
    string key = "SecretKeySecretKeySecret";
    using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
    {
        byte[] iv0 = { 0, 0, 0, 0, 0, 0, 0, 0 };
        byte[] toEncryptArray = Encoding.ASCII.GetBytes(toEncrypt);
        tdes.IV = iv0;
        tdes.Key = Encoding.ASCII.GetBytes(key);
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.Zeros;
        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray =
            cTransform.TransformFinalBlock(toEncryptArray, 0,
                toEncryptArray.Length);
        tdes.Clear();
        string s = Convert.ToBase64String(resultArray);
    }
