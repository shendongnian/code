    // Now it picks then right one
    public static void PicksWrongOverload<T>()
    {
        Extensions.Test((dynamic)new Generic<T>());
    }
