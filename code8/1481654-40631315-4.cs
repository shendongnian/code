    public bool ContainsNumber(string s)
    {
        // Same as before, just uses a list
        var numbers = new List<string>() { "1", "2", "3", ... , "one", "two", "three" };
        // Split the provided string into words
        var words = s.Split(' ').ToList();
        // Uses LINQ Intersect to see if the list of words contains any numbers
        return words.Intersect(numbers).Any();
    }
