    public static void Foo<T>(IValueProvider<T> provider) where T : class
    {
        // Variable is of type T
        var mystery = provider?.Value;
    }
