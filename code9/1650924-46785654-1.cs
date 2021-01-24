    public static A RandomlyCreateA(Random rng)
    {
        var types = Assembly.GetAssembly(typeof(A)).GetTypes().Where(t => t.IsSubclassOf(typeof(A))).ToArray();
        return Activator.CreateInstance(types[rng.Next(types.Length)]) as A;
    }
