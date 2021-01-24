    var chars = new HashSet<char>();
    foreach (char c in input)
    {
        if (chars.Contains(c))
        {
            // c is not unique
        }
        else
        {
            chars.Add(c);
        }
    }
