    public string encoding(string toEncode)
    {
    byte[] bytes= Encoding.GetEncoding(28591).GetBytes(toEncode);
    string toReturn = System.Convert.ToBase64String(bytes);
    return toReturn;
    }
