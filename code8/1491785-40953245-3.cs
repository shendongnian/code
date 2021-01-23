    HashSet<string> temp2 = new HashSet<string>();
    foreach (var word in SecondFileWords)
    {
        if (!string.IsNullOrEmpty(word) && !temp2.Contains(word))
        {
            temp2.Add(word);
        }
    }
