    public string RemoveExtensiveWhiteSpace(string s)
    {
        s = Regex.Replace(s, @"\r\n|\n\r|\n|\r", "\r\n"); //normalize all type of line breaks to \r\n
        s = Regex.Replace(s, @"[ \t]+", " "); // \t+|[\t ]{2,}
        s = s.Replace("\r\n ", "\r\n").Replace(" \r\n", "\r\n"); //Regex.Replace(s, @"(\r\n | \n\r)", "\r\n")
        s = Regex.Replace(s, @"(\r\n){2,}", "\r\n\r\n"); //replace 2+ new line breaks with 2
        return s.Trim('\r', '\n', ' '); //remove initial & final white space chars
    }
