    foreach (char letter in word)
    {
        string c = letter.ToString();
        if (input.Contains(c))
        {
            letters++;
            remaining.Remove(c);
            input = remaining.ToString();
        }
    }
