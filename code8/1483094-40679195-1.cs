    public static Category CreateCategory(string line)
    {
        if (line == "Engineering")
        {
            return new EngineeringCategory();
        }
        // Whatever you want to do for non-engineering categories
    }
