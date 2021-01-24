    private static string filterString(string input)
    {
        var groups = input.GroupBy(c => c);
        var output = new string(groups.Select(g => g.Key).ToArray());
        return output;
    }
