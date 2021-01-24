    public static string ReverseString(string word)
    {
        return string.IsNullOrWhiteSpace(word) ? string.Empty 
            :  string.Concat(word.Reverse());
    }
