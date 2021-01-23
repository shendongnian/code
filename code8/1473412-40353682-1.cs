    for (int i = 0; i < sentence.Length; i++)
    {
        if (string.Equals(sentence.Substring(i, 1), "z", StringComparison.OrdinalIgnoreCase))
        {
            total++;
        }
    }
