    string RemoveInternalPipe(string line)
    {
        int count = 0;
        var temp = new List<char>(line.Length);
        foreach (var c in line)
        {
            if (c == '\'')
            {
                ++count;
            }
            if (c == '|' && count % 2 != 0) continue;
            temp.Add(c);
        }
        return new string(temp.ToArray());
    };
    File.WriteAllLines(@"yourOutputFile",
        File.ReadLines(@"yourInputFile").Select(x => RemoveInternalPipe(x)));
