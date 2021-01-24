    public static IEnumerable<string> CustomSplit(this string s)
    {
        var buffer = new StringBuilder();
        foreach (var c in s)
        {
            if (!char.IsLetterOrDigit(c))
            {
                if (buffer.Length > 0)
                {
                    yield return buffer.ToString();
                    buffer.Clear();
                }
            }
            else
            {
                buffer.Append(c);
            }
        }
        if (buffer.Length > 0)
            yield return buffer.ToString();
    }
