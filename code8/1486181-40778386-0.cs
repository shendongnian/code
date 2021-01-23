    private static readonly IEnumerable<string> staticReadOnlyData = Array.AsReadOnly( new string[] { "someKey0", "someKey1", "someKey2", ... } );
    public bool SomeThreadSharedCall(string toCheck)
    {
        // #1
        foreach (string s in staticReadOnlyData)
        {
            if (s == toCheck)
                return true;
        }
        return false;
        // #2
        return staticReadOnlyData.Contains(toCheck);
        // or #3
        return staticReadOnlyData.Any(s => string.Compare(toCheck, s, StringComparison.OrdinalIgnoreCase) == 0);
    }
