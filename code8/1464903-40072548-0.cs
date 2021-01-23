public string encryptMAC(string indata, **byte[] key**)
{
    byte[] resultCrypt;
    UTF8Encoding utf8 = new UTF8Encoding();
    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
    tdes.Mode = CipherMode.ECB;
    tdes.Padding = PaddingMode.PKCS7;
    **tdes.Key = key;**
    byte[] encrypt = utf8.GetBytes(indata);
    try
    {
        ICryptoTransform encryptor = tdes.CreateEncryptor();
        resultCrypt = encryptor.TransformFinalBlock(encrypt, 0, encrypt.Length);
    }
    finally
    {
        tdes.Clear();
    }
    return Convert.ToBase64String(resultCrypt);
}
public string decryptMAC(string indata, **byte[] key**)
{
    byte[] resultDecrypt;
    UTF8Encoding utf8 = new UTF8Encoding();
    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
    tdes.Mode = CipherMode.ECB;
    tdes.Padding = PaddingMode.PKCS7;
    **tdes.Key = key;**
    byte[] decrypt = Convert.FromBase64String(indata);
    try
    {
        ICryptoTransform decryptor = tdes.CreateDecryptor();
        resultDecrypt = decryptor.TransformFinalBlock(decrypt, 0, decrypt.Length);
    }
    catch (CryptographicException ex)
    {
        Console.WriteLine(ex);
    }
    finally
    {
        tdes.Clear();
    }
    return utf8.GetString(decrypt);
}
