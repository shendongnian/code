    public string GetChecksum(string stringToEncrpyt)
    {
        string hash = "";
        using(MD5 md5Hash = MD5.Create())
        {
            hash = GetMD5Hash(md5Hash, stringToEncrpyt);
        }
        return hash;
    }
    private string GetMD5Hash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sb.Append(data[i].ToString("x2"));
        }
        return sb.ToString();
    }
