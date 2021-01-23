    var text = "hfdaa732ibgedsoju";
    var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
    var vowelFrequency = text.Where(c => vowels.Contains(c))
                             .GroupBy(c => c)
                             .ToDictionary(g => g.Key, g.Value.Count());
