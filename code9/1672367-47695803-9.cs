    public string Test(string someAName)
    {
        if (myOptionMap.TryGetValue(someAName, out var myOption))
        {
            return myOption.bName;
        }
        // Oops not found
        return string.Empty;
    }
