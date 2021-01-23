    public bool ContainsNumber(string s)
    {
        // Same as before, just uses a list
        var numbers = new List<string>() { "1", "2", "3", ... , "one", "two", "three" };
        // Split the provided string into words
        var words = s.Split(' ').ToList();
        // As per AndyJ's reccomendation, make this case AND culture insensitive
        return words.Any(w => numbers.Any(n => n.Equals(w, StringComparison.OrdinalIgnoreCase)));
    }
