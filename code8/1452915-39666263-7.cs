    public Main()
    {
        var strings = new string[]{ "AB GF", "|AB| GF" };
        foreach (var s in strings)
        {
            var subStrings = s.Split(' ');
            for (int i = 0; i < subStrings.Count(); i++)
            {
                if (subStrings[i].Contains("|"))
                    subStrings[i] = subStrings[i].Replace("|", String.Empty);
                else
                    subStrings[i] = ReplaceText(subStrings[i]);
            }
            Console.WriteLine(String.Join(" ", subStrings));
        }
    }
    string ReplaceText(string text)
    {
        text = text.Replace("AB", "CD");
        text = text.Replace("GF", "HI");
        text = text.Replace("AC", "QW");
        return text.Replace("VB", "GG");
    }
