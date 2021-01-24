    private class NoCons
    {
        private NoCons()
        {
        }
    }
    static void Main(string[] args)
    {
        // As you saw, this shows one declared constructor
        Type exploratory = typeof(NoCons);
        // Returns nothing
        ConstructorInfo[] constructors = typeof(NoCons).GetConstructors();
        // Returns 1 constructor
        constructors = typeof(NoCons).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    }
