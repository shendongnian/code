    public static ITree<T> GetNextNonIgnoreChild(this ITree<T> input)
    {
        while (input != null && input.Ignore) input = input.Child;
        return input;
    }
