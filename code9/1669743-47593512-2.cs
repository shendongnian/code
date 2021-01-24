    public static int getvalue (string c)
    {
        List<string> wordlist = new List<string> { "sam", "paddy", "murphy", "saint"};
        return wordlist.Any(c.Contains) ? 100 : -10;
    }
