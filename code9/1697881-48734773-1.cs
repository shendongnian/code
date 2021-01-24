    public string removePunctuation(string s) 
    {
        string result = Regex.Replace(s, @"[^\w\s]", "");
        return result;
    }
