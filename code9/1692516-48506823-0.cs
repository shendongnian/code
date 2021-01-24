    string[] names = { "Burke", "Connor", "Frank",
                   "Everett", "Albert", "George",
                   "Harris", "David" };
    Dictionary<string, string> replaceRules =
        new Dictionary<string, string>
            {
                { "Connor", "Jonnor" },
                { "Albert", "Jalbert" },
                { "David", "Javid" },
            };
    // Solution1: Get new IEnumerable with 
    // replaced names which can be converted to array or list
    IEnumerable<string> replacedNames = 
        names.Select(n => replaceRules.ContainsKey(n) ? replaceRules[n] : n);
    // Solution2: Change values in original array
    for (int i = 0; i < names.Length; i++)
    {
        if (replaceRules.ContainsKey(names[i]))
        {
            names[i] = replaceRules[names[i]];
        }
    }
