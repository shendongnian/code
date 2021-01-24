    var sb = new StringBuilder();
    using (var sha1 = SHA1.Create())
    {
        byte[] byteHash = sha1.ComputeHash(Encoding.UTF8.GetBytes(HashData));
        foreach (byte bh in byteHash)
        {
            sb.Append(String.Format("{0:X2}", bh));
        }
    }
    string result = sb.ToString();
