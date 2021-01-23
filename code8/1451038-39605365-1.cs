    string input = "[952,M] [782,M] [782] {2[373,M]} [1470] [352] [235] [234] {3[610]}{3[380]} [128] [127]";
    int pos = 0;
    void Main()
    {
        while (pos < input.Length)
        {
            SkipWhitespace();
            if (pos < input.Length && input[pos] == '{')
                ParseBrace();
            else if (pos < input.Length && input[pos] == '[')
                ParseBracket();
        }
    }
    void SkipWhitespace()
    {
        while (pos < input.Length && char.IsWhiteSpace(input[pos]))
            pos++;
    }
    void ParseBrace()
    {
        Debug.Assert(pos < input.Length && input[pos] == '{');
        int pos2 = input.IndexOf('[', pos + 1);
        if (pos2 < 0)
            pos2 = input.Length;
        int count = int.Parse(input.Substring(pos + 1, pos2 - pos - 1));
        for (int i = 0; i < count; i++)
        {
            pos = pos2;
            ParseBracket();
        }
        pos2 = input.IndexOf('}', pos2 + 1);
        if (pos2 < 0)
            pos2 = input.Length;
        pos = pos2 + 1;
    }
    void ParseBracket()
    {
        Debug.Assert(pos < input.Length && input[pos] == '[');
        int pos2 = input.IndexOf(']', pos + 1);
        if (pos2 < 0)
            pos2 = input.Length;
        Console.WriteLine(input.Substring(pos + 1, pos2 - pos - 1));
        pos = pos2 + 1;
    }
