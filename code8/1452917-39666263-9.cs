    public Main()
    {
        var strings = new string[]{ "AB GF", "|AB| GF" };
        foreach (var s in strings)
            Console.WriteLine(String.Join(" ", s.Split(' ').Select(x => ReplaceText(x))));
    }
    string ReplaceText(string text)
    {
        if (text.Contains("|"))
            return text.Replace("|", String.Empty);
        else
        {
            text = text.Replace("AB", "CD");
            text = text.Replace("GF", "HI");
            text = text.Replace("AC", "QW");
            return text.Replace("VB", "GG");
        }
    }
