public string encryptMAC(string indata, <b>byte[] key</b>)
{
    byte[] resultCrypt;
    UTF8Encoding utf8 = new UTF8Encoding();
    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
    tdes.Mode = CipherMode.ECB;
    tdes.Padding = PaddingMode.PKCS7;
    <b>tdes.Key = key;</b>
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
public string decryptMAC(string indata, <b>byte[] key</b>)
{
    byte[] resultDecrypt<b> = new byte[0]</b>;
    UTF8Encoding utf8 = new UTF8Encoding();
    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
    tdes.Mode = CipherMode.ECB;
    tdes.Padding = PaddingMode.PKCS7;
    <b>tdes.Key = key;</b>
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
    return utf8.GetString(<b>resultDecrypt</b>);
}
