    static void Main(string[] args)
    {
        List<byte> extend1 = new List<byte> { 0x1 }, extend2 = new List<byte> { 0x2 };
    
        string randomString = "mypassword";
        IEnumerable<byte> passwordBytesScrypt = Encoding.UTF8.GetBytes(randomString).Concat(extend1);
    
        string salt = "salt@gmail.com";
        IEnumerable<byte> saltBytesScrypt = Encoding.UTF8.GetBytes(salt).Concat(extend1);
    
        byte[] scryptBytes = CryptSharp.Utility.SCrypt.ComputeDerivedKey(passwordBytesScrypt.ToArray(), saltBytesScrypt.ToArray(), 1 << 18, 8, 1, null, 32);
    
        byte[] passwordBytesPBKDF2 = passwordBytesScrypt.Take(passwordBytesScrypt.Count() - 1).Concat(extend2).ToArray();
        byte[] saltBytesPBKDF2 = saltBytesScrypt.Take(saltBytesScrypt.Count() - 1).Concat(extend2).ToArray();
    
        byte[] pbkdf2Bytes = CryptSharp.Utility.Pbkdf2.ComputeDerivedKey(new HMACSHA256(passwordBytesPBKDF2), saltBytesPBKDF2, 65536, 32);
    
        Console.WriteLine(BitConverter.ToString(scryptBytes).Replace("-", ""));
        Console.WriteLine(BitConverter.ToString(pbkdf2Bytes).Replace("-", ""));
    }
