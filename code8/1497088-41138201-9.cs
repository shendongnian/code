    string somevar = "rat";
    List<string> subStrings = new List<string>();
    for (int i = 0; i < somevar.Length; i++)
    {
        subStrings.AddRange(GetAllSubStrings(somevar, i + 1));
    }
    // subStrings = {"rat", "at", "ra", "r", "a", "t"}
