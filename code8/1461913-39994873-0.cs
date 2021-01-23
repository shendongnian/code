    public static string BCEncrypt(string input, out string iv_base64)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        SecureRandom random = new SecureRandom();
        byte[] iv = new byte[16];
        random.NextBytes(iv);
        iv_base64 = Convert.ToBase64String(iv);
        string keyString = "mysecretkey12345";
        string keyStringBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(keyString));
        //Set up
        AesEngine engine = new AesEngine();
        CbcBlockCipher blockCipher = new CbcBlockCipher(engine); //CBC
        PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new Pkcs7Padding());
        KeyParameter keyParam = new KeyParameter(Convert.FromBase64String(keyStringBase64));
        ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, iv, 0, 16);
        // Encrypt
        cipher.Init(true, keyParamWithIV);
        byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
        int length = cipher.ProcessBytes(inputBytes, outputBytes, 0);
        cipher.DoFinal(outputBytes, length); //Do the final block
        return Convert.ToBase64String(outputBytes);
    }
    public static string BCDecrypt(string input, string iv_base64)
    {
        string keyString = "mysecretkey12345";
        string keyStringBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(keyString));
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] iv = Convert.FromBase64String(iv_base64);
        //Set up
        AesEngine engine = new AesEngine();
        CbcBlockCipher blockCipher = new CbcBlockCipher(engine); //CBC
        PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine), new Pkcs7Padding());
        KeyParameter keyParam = new KeyParameter(Convert.FromBase64String(keyStringBase64));
        ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, iv, 0, 16);
        //Decrypt            
        byte[] outputBytes = Convert.FromBase64String(input);
        cipher.Init(false, keyParamWithIV);
        byte[] comparisonBytes = new byte[cipher.GetOutputSize(outputBytes.Length)];
        int length = cipher.ProcessBytes(outputBytes, comparisonBytes, 0);
        cipher.DoFinal(comparisonBytes, length); //Do the final block
        return Encoding.UTF8.GetString(comparisonBytes, 0, comparisonBytes.Length);
    }
