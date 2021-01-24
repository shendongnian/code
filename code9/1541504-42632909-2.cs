    public static string Decrypt(byte[] x)
    {
        byte[] plainKey;
        using(var desObj = Rijndael.Create()) //this should be a local variable and be disposed of.
        {
            plainKey = Encoding.ASCII.GetBytes("0123456789abcdef");//Change the key.
            desObj.Key = plainKey;
            desObj.Mode = CipherMode.CFB;
            desObj.Padding = PaddingMode.PKCS7;
            using(MemoryStream ms = new MemoryStream(x)) //pass the byte[] in to the memory stream.
            using(CryptoStream cs = new CryptoStream(ms, desObj.CreateDecryptor(), CryptoStreamMode.Read)) //this should be disposed of instead of calling .Close manually.
            using(StreamReader sr = new StreamReader(cs, Encoding.ASCII))
            {
                return sr.ReadToEnd();
            }
        }
    }
