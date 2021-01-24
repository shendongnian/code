    public static string[] SplitString(string input)
    {
        return Regex.Split(input, "AAA|BBB");
    }
    foreach (string word in SplitString("sssAAAvvvBBBuuu"))
    {
        ........
        ........
