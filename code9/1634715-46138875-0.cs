    using (var md5 = System.Security.Cryptography.MD5.Create())
    {
        byte[] hashValue = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sb = new StringBuilder();
        foreach (byte b in hashValue)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
