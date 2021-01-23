    IEnumerable<string> GetParameterNames(string signature)
    {
        var openBraces = 0;
        var buffer = new StringBuilder();
        foreach (var c in signature)
        {
            if (c == '{')
            {
                openBraces++;
            }
            else if (c == '}')
            {
                openBraces--;
            }
            else if (c == ',' && openBraces == 0)
            {
                if (buffer.Length == 0)
                    throw new FormatException(); //syntax is not right.
                yield return buffer.ToString();
                buffer.Clear();
            }
            buffer.Append(c);
        }
        if (buffer.Length == 0 || openBraces != 0)
            throw new FormatException(); //syntax is not right.
        yield return buffer.ToString();
    }
