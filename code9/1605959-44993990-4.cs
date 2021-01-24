    private void addToDictionary(Dictionary<string, int> words, List<string> list)
    {
        foreach (string item in list)
        {
            if (words.ContainsKey(item))
            {
                words[item] += 1;
            }
            else
            {
                words.Add(item, 1);
            }
        }
    }
