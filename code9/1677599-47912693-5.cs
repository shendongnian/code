    //MD5 Hash method 
    public string MD5(string input)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        //Convert the input string to a byte array and computer the hash, return the hexadecimal  
        byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        string result = BitConverter.ToString(bytes).Replace("-", string.Empty);
        return result.ToLower();
    }
