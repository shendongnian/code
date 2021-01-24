    var dictionary = new Dictionary<string, Dictionary<string, HashSet<string>>>();
    for (int i = 1; i <= rowCount; i++)
    {
        var country = xlRange.Cells[i, 1].Value2.ToString();
        var state = xlRange.Cells[i, 2].Value2.ToString();
        var name = xlRange.Cells[i, 3].Value2.ToString();
        // Add this country if it doesn't exist
        if (!dictionary.ContainsKey(country))
        {
            dictionary[country] = new Dictionary<string, HashSet<string>>();
        }
        // Add this state if it doesn't exist
        if (!dictionary[country].ContainsKey(state))
        {
            dictionary[country].Add(state, new HashSet<string>());
        }
        // Add this name if it doesn't exist
        if (!dictionary[country][state].Contains(name))
        {
            dictionary[country][state].Add(name);
        }
    }
