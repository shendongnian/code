    public static int getvalue (string c)
    {
       //here would be creating a list
       List<string> wordlist = new List<string> { "sam", "paddy", "murphy", "saint"};
        return wordlist.Contains(c) ? 100 : -10;
    }
