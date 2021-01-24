    public string removePunctuation(string s) 
    {
        var result = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            if (Char.IsWhiteSpace(s[i])) {
                result.Append(" ");
            } else if (!Char.IsLetter(s[i]) && !Char.IsNumber(s[i])) {
                // do nothing
            } else {
                result.Append(s[i]);
            }
        }
        return result.ToString();
    }
