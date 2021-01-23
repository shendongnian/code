    string[] BlockSplit(string source, char separator, params int[] blocks)
    {
        string[] parts = source.Split(separator);
        List<string> splitted = new List<string>();
        
        int skipped = 0;
        foreach (int x in blocks)
        {
            string block = string.Join(separator.ToString(), parts.Skip(skipped).Take(x));
            skipped += x;
            splitted.Add(block);
        }
        return splitted.ToArray();
    }
