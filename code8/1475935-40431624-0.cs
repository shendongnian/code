    public static string MD5Hash(string input)
    {
        using (var md5 = MD5.Create())
        {
            var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return Encoding.ASCII.GetString(result);
        }
    }
