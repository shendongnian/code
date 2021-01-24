    public static List<int[]> Parse(List<string> list)
    {
        int line = 0;
        int item = 0;
        try
        {
            return list
                .Select(str => {
                    line++;
                    item = 0;
                    return str
                        .Split(';')
                        .Select(i => { item++; return int.Parse(i); })
                        .ToArray();
                })
                .ToList();
        }
        catch
        {
            throw new FormatException($"Wrong line [{line}]; item [{item}]");
        }
    }
