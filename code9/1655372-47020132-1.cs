    public string RSASign(string data, string PhysicalApplicationPath)
    {
        RSA rsa = LoadCertificateFile(PhysicalApplicationPath);
        byte[] dataBytes = System.Text.Encoding.Default.GetBytes(data);
        byte[] signatureBytes = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return BitConverter.ToString(signatureBytes).Replace("-", null);
    }
