    public string Expand(string message)
    {
        string[] splits = message.Split(' ');
        for (int i = 0; i < splits.Length; i++)
        {
            string key = dictionary.Keys.FirstOrDefault(x => x == splits[i].ToUpper());
            if (key != null)
            {
                splits[i] = (key + " " + dictionary[key]).ToLower();
            }
        }
        return string.Join(" ", splits);
    }
