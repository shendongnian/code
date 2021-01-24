    private static SymmetricAlgorithm GetAlgorithm(string password)
    {
        Rijndael algorithm = Rijndael.Create();
        using (Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(password, new byte[]
        {
            0x53, 0x6f, 0x64, 0x69, 0x75, 0x6d, 0x20, 0x43, 0x68, 0x6c, 0x6f, 0x72, 0x69, 0x64, 0x65
        }))
        {
            algorithm.Padding = PaddingMode.ISO10126;
            algorithm.Key = rdb.GetBytes(32);
            algorithm.IV = rdb.GetBytes(16);
        }
        return algorithm;
    }
