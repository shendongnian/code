    Dictionary<string, int> temp1 = new Dictionary<string, int>();
    foreach (var word in FirstFileWords)
    {
        if (string.IsNullOrEmpty(word))
        {
            continue;
        }
        if (temp1.ContainsKey(word))
        {
            temp1[word]++;
        }
        else
        {
            temp1.Add(word, 1);
        }
    }
