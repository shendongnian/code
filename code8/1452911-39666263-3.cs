    public Main()
    {
        var strings = new string[]{ "AB GF", "|AB GF|" };
        foreach (var s in strings)
        {
            if (s.Contains("|"))
                Console.WriteLine(s.Replace("|", String.Empty));
            else
                Console.WriteLine(ReplaceText(s));
        }
    }
    string ReplaceText(string text)
    {
        text = text.Replace("AB", "CD");
        text = text.Replace("GF", "HI");
        text = text.Replace("AC", "QW");
        return text.Replace("VB", "GG");
    }
