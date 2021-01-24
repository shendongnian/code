    public static int getvalue (string c)
    {
       //here would be creating a list
       List<string> wordlist = new List<string> { "sam", "paddy", "murphy", "saint"};
        return wordlist.Any(c.Contains) ? 100 : -10;
    }
