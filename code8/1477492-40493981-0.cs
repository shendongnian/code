    var names = new HashSet<string>();
    names.Add(NormaliseName("Tom"));
    names.Add(NormaliseName("Peter"));
    names.Add(NormaliseName("John"));
    var normalisedTestName = NormaliseName("Tony");
    if (names.Contains(normalisedTestName ))
    {
        // Already exists
    }
    else
    {
        // Doesn't exist, add to hashset
        names.Add(normalisedTestName);
    }
    private static string NormaliseName(string name){
        return name.ToLower().Trim();
    }
