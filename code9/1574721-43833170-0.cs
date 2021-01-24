    public static string GetSubset(string input = "LKAH8slfsfjlllj9lkjlkjasdf;lk7ljasdflkasdjsfdljk")
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        foreach(String s in input.Split(new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).OrderByDescending(x => x.Length))
        {
            foreach (char c in s)
                if (char.IsUpper(c))
                    return s;
        }
        return string.Empty;
    }
